using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToursApp
{
    /// <summary> 
    /// Логика взаимодействия для HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Page
    {
        public HotelsPage()
        {
            InitializeComponent();
            DGridHotels.ItemsSource = RealtorsOperationEntities.GetContext().Realties.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e) // Кнопка редактирования
        {

            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Realty)); // Обращаемся к кнопке которую мы нажали, получать её контекст, мы всегда знаем, что это будет Realty

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) // Кнопка добавления
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e) // Кнопка удаления
        {
            var realtyForRemoving = DGridHotels.SelectedItems.Cast<Realty>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {realtyForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    RealtorsOperationEntities.GetContext().Realties.RemoveRange(realtyForRemoving);
                    RealtorsOperationEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridHotels.ItemsSource = RealtorsOperationEntities.GetContext().Realties.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) // Событие IsVisibleChanged, оно срабатывает каждый раз когда страница отображает или скрывается
        {
            if (Visibility == Visibility.Visible) // Если видимость страницы, то мы будем обращаться к контексту
            {
                RealtorsOperationEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }
    }
}
