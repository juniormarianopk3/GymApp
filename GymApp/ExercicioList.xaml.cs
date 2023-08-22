using GymApp.Data;
using GymApp.Models;

namespace GymApp;

public partial class ExercicioList : ContentPage {



    private IExercicioRepository _repository;

    public List<string> _filtro { get; set; }
    public ExercicioList(List<string> filtro)  {
        InitializeComponent();
        _filtro = filtro;

        
        //_repository.Add(exercicios);

        if (_filtro == null) {
            List<Exercicio> items = _repository.GetAll();
            ExercicioCollection.ItemsSource = items;
        }
        else {
            List<Exercicio> items = _repository.GetByParametro(_filtro);
            ExercicioCollection.ItemsSource = items;
        }
    }
    public ExercicioList(IExercicioRepository repository)  {

        InitializeComponent();
        _repository = repository;
        List<Exercicio> items = _repository.GetAll();
        ExercicioCollection.ItemsSource = items;
       

    }

    private void Image_SizeChanged(object sender, EventArgs e) {
        var image = (Image)sender;
        image.IsAnimationPlaying = false;
        image.IsAnimationPlaying = true;
    }
    private void TapGestureRecognizerTapped_To_ExercicioDetails(object sender, TappedEventArgs e) {
        var grid = (Grid)sender;
        var gesture = (TapGestureRecognizer)grid.GestureRecognizers[0];
        Exercicio exercicios = (Exercicio)gesture.CommandParameter;

        var exercercioDetails = Handler.MauiContext.Services.GetService<ExercercioDetails>();
        exercercioDetails.GetExerciciosToDetails(exercicios);
        Navigation.PushAsync(exercercioDetails);       
    }

    private async void TapGestureRecognizerTapped_ToDelete(object sender, TappedEventArgs e) {

        bool result = await App.Current.MainPage.DisplayAlert("Excluir!", "Tem certeza que deseja excluir?", "Sim", "Não");

        if (result) {
            Exercicio transaction = (Exercicio)e.Parameter;
            _repository.Delete(transaction);

            // Reload();
        }



    }

    private async void ExercicioFiltro_Button(object sender, EventArgs e) {

        await Navigation.PushModalAsync(new ModalExercicioList());
    }
}