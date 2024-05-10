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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Realty _currentRealty = new Realty();

        public AddEditPage(Realty selectedRealty)
        {
            InitializeComponent();
            if (selectedRealty != null )
                _currentRealty = selectedRealty;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e) // Обработчик событий на кнопку сохранить. НО ОНА НЕ ДОБАВЛЯЕТ ИНФОРМАЦИЮ НА СТРАНИЦУ 
        {
            
                RealtorsOperationEntities.GetContext().SaveChanges();// Метод SaveChanges, что б сохранить изменения, но он является опасным
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack(); // Обращаемся к менеджеру, что б вернуть назад
        }
    }
}
