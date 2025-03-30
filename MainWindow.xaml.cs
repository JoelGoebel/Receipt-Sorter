using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace Receipt_Sorter
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<string> ImageFileNames = new List<string>();

        private void DropZone_DragEnter(object sender, DragEventArgs e)
        {
            //Check if the Dataformat of the data can be accepted
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy; // Set the drag drop effect to copy
                DropZone.BorderBrush = Brushes.Green; // Set the border brush to green
            }
            else
            {
                e.Effects = DragDropEffects.None; // not supportet
                DropZone.BorderBrush = Brushes.Red; // Set the border brush to Red
            }
            e.Handled = true; // Mark the event as Handled
        }

        private void DropZone_DragOver(object sender, DragEventArgs e)
        {
            //Check if the Dataformat of the data can be accepted
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy; // Set the drag drop effect to copy
                DropZone.BorderBrush = Brushes.Green; // Set the border brush to green
            }
            else
            {
                e.Effects = DragDropEffects.None; // not supportet
                DropZone.BorderBrush = Brushes.Red; // Set the border brush to Red
            }
            e.Handled = true; // Mark the event as Handled
        }

        private void DropZone_Drop(object sender, DragEventArgs e)
        {
            // Get the dropped files
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                // Check if the files are images
                if (files.All(x => x.EndsWith(".jpg") || x.EndsWith(".png") || x.EndsWith(".jpeg") || x.EndsWith(".img")))
                {
                    // Load the images
                    foreach (string file in files)
                    {                        
                        ImageFileNames.Append(file);
                        int lastBackslash = file.LastIndexOf("\\");
                        string fileName = file.Substring(lastBackslash + 1);
                        DropZoneText.Text += fileName + "\n";

                    }
                    DropZone.BorderBrush = Brushes.Black;
                }
            }
        }

        private void DropZone_DragLeave(object sender, DragEventArgs e)
        {
            DropZone.BorderBrush = Brushes.Black; // Set the border brush to black
            e.Effects = DragDropEffects.None; // not supportet
            e.Handled = true; // Mark the event as Handled
        }
    }
}
