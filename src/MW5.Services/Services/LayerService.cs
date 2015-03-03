﻿using System;
using System.Windows.Forms;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Api.Static;
using MW5.Plugins.Interfaces;
using MW5.Services.Abstract;

namespace MW5.Services
{
    public class LayerService: ILayerService
    {
        private readonly IAppContext _context;
        private readonly IFileDialogService _fileDialogService;
        private readonly IMessageService _messageService;

        public LayerService(IAppContext context, IFileDialogService fileDialogService, IMessageService messageService)
        {
            _context = context;
            _fileDialogService = fileDialogService;
            _messageService = messageService;
        }

        public bool RemoveSelectedLayer()
        {
            int layerHandle = _context.Legend.SelectedLayer;
            if (layerHandle == -1)
            {
                _messageService.Info("No selected layer to remove.");
                return false;
            }

            var layer = _context.Map.Layers.ItemByHandle(layerHandle);
            if (_messageService.Ask(string.Format("Do you want to remove the layer: {0}?", layer.Name)))
            {
                _context.Map.Layers.Remove(layerHandle);
                return true;
            }
            return false;
        }

        public void AddLayer(LayerType layerType)
        {
            string[] filenames;
            if (!_fileDialogService.OpenFiles(layerType, _context.MainWindow, out filenames))
            {
                return;
            }

            _context.Map.LockWindow(true);

            foreach (var name in filenames)
            {
                AddLayersFromFilename(name);
            }

            _context.Map.ZoomToMaxExtents();
            _context.Map.LockWindow(false);

            _context.Legend.Redraw();
        }

        private void AddLayersFromFilename(string filename)
        {
            try
            {
                var ds = GeoSourceManager.Open(filename);

                if (ds == null)
                {
                    _messageService.Warn(string.Format("Failed to open datasource: {0} \n {1}", filename, GeoSourceManager.LastError));
                    return;
                }

                foreach (var layer in LayerSourceHelper.GetLayers(ds))
                {
                    _context.Map.Layers.Add(layer);
                }
            }
            catch (Exception ex)
            {
                _messageService.Warn(string.Format("There was a problem opening layer: {0}. \n Details: {1}", filename, ex.Message));
            }
        }
    }
}
