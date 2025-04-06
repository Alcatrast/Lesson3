using System.Windows;
using System.Windows.Controls;


namespace ButtonRunning;

public partial class MainWindow : Window
{
    public MainWindow() //Конструктор окна, запускается при создании окна  
    {
        InitializeComponent(); //служебный метод для загрузки компонентов окна
        
        random = new Random(); //Наша инициализация рандома при запуске окна 
    }

    private readonly Random random; //Внешняя переменная хранения рандома 

    private void Button_MouseEnter(object sender, RoutedEventArgs e) //Событие, запускающиеся при наведении мышки на любую из кнопок 
    {
        Button currentButton = (Button)sender; // Приводим объект отправителя к кнопке, так как мы знаем что событие точно вызвала кнопка 
        currentButton.Visibility = Visibility.Hidden; //Делаем кнопку, Которая вызвала событие , невидимой 
       
        
        List<object> tempList = new List<object>();
        foreach (var el in ((Grid)currentButton.Parent).Children) tempList.Add(el);
        // Создаем наш отдельный список tempList и копируем в него элементы циклом foreach из коллекции ((Grid)currentButton.Parent).Children

        // foreach - специальный цикл созданный для обхода коллекций, можно использовать и другие циклы это неважно.

        // currentButton.Parent - получаем родительский компонент которому принадлежит наша кнопка
        // (Grid)currentButton.Parent - мы знаем, что родительский компонент точно является Grid-ом, поэтому мы вызываем его как Grid 
        // ((Grid)currentButton.Parent).Children - получаем коллекцию детей нашего Grid-а, в нашем случае всех кнопок, которые в нем находятся 


        tempList.Remove(currentButton); // удаляем ссылку на нашу кнопку из коллекции tempList, чтобы случайно не выбрать ее индекс рандомом и она точно переместилась

        // Мы специально поэлементно циклом добавляли кнопки в tempList, чтобы удаление наши текущей кнопки удалила ее только из нашей коллекции, а не из программы в целом!!!

        int state = random.Next(0, tempList.Count); // Выбираем случайное число от нуля до tempList.Count - 1. чтобы использовать его как индекс выбора следующей кнопки которая станет видимой.  
        if (tempList[state] is Button nextButton) nextButton.Visibility = Visibility.Visible; // делаем случайную кнопку из коллекции видимой 

        // Используемая конструкция - if(tempList[state] is Button nextButton) - аналогичная конструкции - Button nextButton = (Button)temp[state]
        // Только if говорит нам, является ли элемент из коллекции кнопкой а не чем то другим, что мы могли получить из детей Grid-а И могло бы вызвать ошибки 
    }
}