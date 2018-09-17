using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace task_DI
{
    class CustomView
    {
        public CustomerView()
   {
        DataContext = new CustomerViewModel();
   }
}
 
public class CustomerViewModel
{
    private ICollectionView _customerView;
 
    public ICollectionView Customers
    {
        get { return _customerView; }
    }
 
    public CustomerViewModel()
    {
        IList<Tasks> customers = GetCustomers();
        _customerView = CollectionViewSource.GetDefaultView(customers);
    }
    }
}
