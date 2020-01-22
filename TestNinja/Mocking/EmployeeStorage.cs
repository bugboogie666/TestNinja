using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    class EmployeeStorage : IEmployeeStorage
    {
        private EmployeeContext _db;

        public EmployeeStorage()
        {
            _db = new EmployeeContext();
        }

        public void DeleteRecord(int recordId)
        {
            var employee = _db.Employees.Find(recordId);
            if (employee == null)
                return;
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            
        }
    }



}
