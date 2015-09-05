﻿// -------------------------------------------------------------------------------------------
// <copyright file="TaskCollection.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MW5.Plugins.Enums;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;

namespace MW5.Tools.Model
{
    internal class TaskCollection : ITaskCollection
    {
        private readonly List<IGisTask> _tasks = new List<IGisTask>();

        public event EventHandler Cleared;

        public event EventHandler<TaskEventArgs> TaskChanged;

        public int Count
        {
            get { return _tasks.Count; }
        }

        public void Add(IGisTask task)
        {
            task.StatusChanged += (s, e) => FireTaskChanged(e.Task, TaskEvent.StatusChanged);
            _tasks.Add(task);
            FireTaskChanged(task, TaskEvent.Added);
        }

        public void Remove(IGisTask task)
        {
            _tasks.Remove(task);
            FireTaskChanged(task, TaskEvent.Removed);
        }

        public void Clear(bool finishedOnly)
        {
            if (finishedOnly)
            {
                lock (_tasks)
                {
                    for (int i = _tasks.Count - 1; i >= 0; i--)
                    {
                        var task = _tasks[i];
                        if (task.IsFinished)
                        {
                            Remove(task);
                        }
                    }
                }
            }
            else
            {
                _tasks.Clear();
                FireCollectionCleared();    
            }
        }

        public void CancelAll()
        {
            foreach (var t in this)
            {
                if (!t.IsFinished)
                {
                    t.Cancel();
                }
            }
        }

        public IEnumerator<IGisTask> GetEnumerator()
        {
            return _tasks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void FireCollectionCleared()
        {
            var handler = Cleared;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        private void FireTaskChanged(IGisTask task, TaskEvent taskEvent)
        {
            var handler = TaskChanged;
            if (handler != null)
            {
                handler(this, new TaskEventArgs(task, taskEvent));
            }
        }
    }
}