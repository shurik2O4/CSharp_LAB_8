using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinUIEx;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LAB_8 {
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : WindowEx {
        private ObservableCollection<Shape> shapes = new();
        private ObservableCollection<string> shapesDesc = new();

        public MainWindow() {
            InitializeComponent();

            ShapeListBox.ItemsSource = shapes;

            shapes.CollectionChanged += Shapes_CollectionChanged;
        }

        private void Shapes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
            // Check if we need to enable the clear button
            ClearButton.IsEnabled = !(shapes.Count == 0);

            // Update descriptions?

        }

        private void AddShapeSquare_Click(object sender, RoutedEventArgs e) {
            Random R = new();
            Shape shape = new Square(Math.Round(R.NextDouble() * R.Next(10, 30), 3));

            if (ShapeListBox.SelectedIndex == -1)
                // Add to the end of the list
                shapes.Add(shape);
            else
                shapes.Insert(ShapeListBox.SelectedIndex, shape);
        }

        private void AddShapeTriangle_Click(object sender, RoutedEventArgs e) {
            Random R = new();
            Shape shape = new Triangle(Math.Round(R.NextDouble() * R.Next(10, 30), 3));

            if (ShapeListBox.SelectedIndex == -1)
                // Add to the end of the list
                shapes.Add(shape);
            else
                // Or insert on the selected position
                shapes.Insert(ShapeListBox.SelectedIndex, shape);
        }

        private void DeleteSelectedButton_Click(object sender, RoutedEventArgs e) {
            shapes.RemoveAt(ShapeListBox.SelectedIndex);
            // Make sure to clear selection so it won't raise index error
            ShapeListBox.SelectedIndex = -1;

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e) {
            shapes.Clear();
        }

        private void ShapeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            DeleteSelectedButton.IsEnabled = !(ShapeListBox.SelectedIndex == -1);
        }

        private void ExitApplication(object sender, RoutedEventArgs e) {
            Environment.Exit(0);
        }

        private bool eight = true;
        private void Hyperlink_Click(Hyperlink sender, HyperlinkClickEventArgs args) {
            if (eight) {
                sender.Inlines.Clear();
                sender.Inlines.Add(new Run() { Text = "🎉" });
            }
            else {
                sender.Inlines.Clear();
                sender.Inlines.Add(new Run() { Text = "№8" });
            }

            eight = !eight;
        }
    }
}
