using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CustomerProcessManager : ICustomerProcessService
    {
        private readonly ICustomerProcessDal _customerProcessDal;
        private readonly IUnitOfWorkDal _unitOfWork;

        public CustomerProcessManager(ICustomerProcessDal customerProcessDal, IUnitOfWorkDal unitOfWork)
        {
            _customerProcessDal = customerProcessDal;
            _unitOfWork = unitOfWork;
        }

        public void TDelete(CustomerProcess t)
        {
            _customerProcessDal.Delete(t);
            _unitOfWork.Save();
        }

        public CustomerProcess TGetByID(int id)
        {
            return _customerProcessDal.GetByID(id);
        }

        public List<CustomerProcess> TGetList()
        {
            return _customerProcessDal.GetList();
        }

        public void TInsert(CustomerProcess t)
        {
            _customerProcessDal.Insert(t);
            _unitOfWork.Save();
        }

        public void TMultiUpdate(List<CustomerProcess> t)
        {
            _customerProcessDal.MultiUpdate(t);
            _unitOfWork.Save();
        }

        public void TUpdate(CustomerProcess t)
        {
            _customerProcessDal.Update(t);
            _unitOfWork.Save();
        }
    }
}
