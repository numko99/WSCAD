using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IO;
using WSCAD.Core;
using WSCAD_Code_Challenge.Drawing;

namespace WSCAD_Code_Challenge.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IShapeLoaderService _shapeLoaderService;
        private readonly IShapeDrawingService _shapeDrawingService;

        public MainViewModel(IShapeLoaderService shapeLoaderService, IShapeDrawingService shapeDrawingService)
        {
            _shapeLoaderService = shapeLoaderService;
            _shapeDrawingService = shapeDrawingService;
        }

        [ObservableProperty]
        private ObservableCollection<Shape> shapes = new();

        public event Action? RequestDrawShapes;

        [RelayCommand]
        private void LoadFile()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Title = "Import file"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var loadedShapes = _shapeLoaderService.LoadShapesFromFile(openFileDialog.FileName);
                Shapes = new ObservableCollection<Shape>(loadedShapes);

                RequestDrawShapes.Invoke();
            }
        }
    }
}
