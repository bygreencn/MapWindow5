﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Properties;

namespace MW5.Menu
{
    /// <summary>
    /// Holds list of commands for the core app. 
    /// </summary>
    internal class MenuCommands : CommandProviderBase
    {
        public MenuCommands(PluginIdentity identity)
            : base(identity)
        {
        }

        protected override void AssignShortcutKeys()
        {
            Commands[MenuKeys.FindLocation].ShortcutKeys = Keys.Control | Keys.F;

            Commands[MenuKeys.NewMap].ShortcutKeys = Keys.Control | Keys.N;

            Commands[MenuKeys.SaveProject].ShortcutKeys = Keys.Control | Keys.S;

            Commands[MenuKeys.OpenProject].ShortcutKeys = Keys.Control | Keys.O;

            Commands[MenuKeys.AddLayer].ShortcutKeys = Keys.Control | Keys.L;

            Commands[MenuKeys.Settings].ShortcutKeys = Keys.Shift | Keys.Alt | Keys.S;

            Commands[MenuKeys.SetScale].ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;

            Commands[MenuKeys.ShowRepository].ShortcutKeys = Keys.Control | Keys.R;

            Commands[MenuKeys.ShowToolbox].ShortcutKeys = Keys.Control | Keys.T;
        }

        public override IEnumerable<MenuCommand> GetCommands()
        {
            return new List<MenuCommand>()
            {
                // file menu
                new MenuCommand("New Map", MenuKeys.NewMap, Resources.icon_new_map, 
                "Removes all the layers and returns default settings for the map."),

                new MenuCommand("Add Layer", MenuKeys.AddLayer, Resources.icon_layer_add,
                "Adds a layer of any supported type, including vector, raster formats and spatial databases."),

                new MenuCommand("Add Vector Layer", MenuKeys.AddVectorLayer, Resources.icon_layer_vector_add,
                "Adds vector layer from the file based datasource."),

                new MenuCommand("Add Raster Layer", MenuKeys.AddRasterLayer, Resources.icon_layer_raster_add,
                "Adds raster layer from the file based datasource."),

                new MenuCommand("Add WMS Layer", MenuKeys.AddWmsLayer, Resources.img_wms_add24,
                "Adds WMS layer to the map."),

                new MenuCommand("Add Database Layer", MenuKeys.AddDatabaseLayer, Resources.icon_layer_database_add,
                "Adds a layer from geodatabase."),

                new MenuCommand("Open Project", MenuKeys.OpenProject, Resources.icon_folder,
                "Opens an existing MapWindow project."),

                new MenuCommand("Save Project", MenuKeys.SaveProject, Resources.icon_save,
                "Saves the current project under the same name or requests for the name if it wasn't yet specified."),

                new MenuCommand("Save Project As", MenuKeys.SaveProjectAs, Resources.icon_save_as,
                "Saves the current project under new name."),

                new MenuCommand("Exit", Plugins.Menu.MenuKeys.Quit, Resources.icon_quit, 
                "Closes the application"),

                new MenuCommand("Test", MenuKeys.Test, Resources.img_test24, 
                "A fast way to run some testing code."),
                
                // file toolbar
                new MenuCommand("Remove Layer", MenuKeys.RemoveLayer, Resources.icon_layer_remove,
                "Removes the layer currently selected in the legend."),

                new MenuCommand("Settings", MenuKeys.Settings, Resources.icon_settings,
                "Opens dialogs with application and plugin settings."),

                // map toolbar
                new MenuCommand("Zoom to Base Layer", MenuKeys.ZoomToBaseLayer, Resources.icon_zoom_to_layer,
                "Zooms map to the bounds of the base TMS layer."),

                new MenuCommand("Zoom In", MenuKeys.ZoomIn, Resources.icon_zoom_in,
                "Zooms in the map."),

                new MenuCommand("Zoom Out", MenuKeys.ZoomOut, Resources.icon_zoom_out,
                "Zooms out the map."),

                new MenuCommand("Zoom to Previous", MenuKeys.ZoomPrev, Resources.img_zoom_prev24,
                "Zooms map to the previous extents recorded in the history."),

                new MenuCommand("Zoom to Next", MenuKeys.ZoomNext, Resources.img_zoom_next24,
                "Zooms map to the next extents recorded in the history."),

                new MenuCommand("Zoom to Maximum Extents", MenuKeys.ZoomMax, Resources.icon_zoom_max_extents,
                "Zooms map to the maximum extents."),

                new MenuCommand("Zoom to Layer", MenuKeys.ZoomToLayer, Resources.icon_zoom_to_layer, 
                "Zooms map to the layer currently selected in the legend."),

                new MenuCommand("Pan", MenuKeys.Pan, Resources.icon_pan,
                "Pans the map, i.e. allows user to move it around with mouse."),

                new MenuCommand("Show Zoom Bar", MenuKeys.ShowZoombar, null, ""),

                new MenuCommand("Show Scale Bar", MenuKeys.ShowScalebar, null, ""),

                new MenuCommand("Show Coordinates", MenuKeys.ShowCoordinates, null, ""),

                new MenuCommand("Show Redraw Time", MenuKeys.ShowRedrawTime, null, ""),

                new MenuCommand("Set Scale", MenuKeys.SetScale, Resources.img_scale24, ""),

                new MenuCommand("Map Projection", MenuKeys.SetProjection, Resources.icon_crs_change,
                "Chooses coordinate system / projection or displays information about current projection."),

                new MenuCommand("Find Location", MenuKeys.FindLocation, Resources.icon_search,
                "Searches for a given location by its name."),

                new MenuCommand("Measure Distance", MenuKeys.MeasureDistance, Resources.icon_measure_distance,
                "Activates tool for measuring distances on the map."),

                new MenuCommand("Measure Area", MenuKeys.MeasureArea, Resources.icon_measure_area,
                "Activates tool for measuring areas on the map."),

                new MenuCommand("By Rectangle", MenuKeys.SelectByRectangle, null, 
                "Selects features of the vector layer currently selected in the legend with rectangle selection tool."),

                new MenuCommand("By Polygon", MenuKeys.SelectByPolygon, null,
                "Selects features of the vector layer currently selected in the legend with polygon selection tool."),

                new MenuCommand("Attributes", MenuKeys.AttributesTool, Resources.icon_identify, 
                "Activates tool to display attributes of vector features."),

                new MenuCommand("Zoom to Selected", MenuKeys.ZoomToSelected, Resources.icon_zoom_to_selection,
                "Zooms the map to the combined extents of all selected features across all layers."),

                new MenuCommand("Clear Selection", MenuKeys.ClearSelection, Resources.icon_clear_selection,
                "Clears selection from all the vector features."), 

                new MenuCommand("Clear Selection", MenuKeys.LayerClearSelection, Resources.icon_clear_selection,
                "Clears selection from all features on the current layer."), 

                new MenuCommand("Clear Layers", MenuKeys.ClearLayers, Resources.icon_layer_clear,
                "Removes all layers from the map."), 

                new MenuCommand("Show Repository", MenuKeys.ShowRepository, Resources.icon_folder,
                "Opens and and sets focus to the repository panel."), 

                new MenuCommand("Show Toolbox", MenuKeys.ShowToolbox, Resources.img_toolbox24,
                "Opens and and sets focus to the toolbox panel."), 
            };
        }
    }
}
