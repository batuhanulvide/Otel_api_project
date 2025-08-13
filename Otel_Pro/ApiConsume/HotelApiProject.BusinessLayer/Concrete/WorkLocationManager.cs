using HotelApiProject.BusinessLayer.Abstract;
using HotelApiProject.DataAccessLayer.Abstract;
using HotelApiProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiProject.BusinessLayer.Concrete
{
    public class WorkLocationManager : IWorkLocationService
    {
        private readonly IWorkLocationDAL _WorkLocationDAL;

        public WorkLocationManager(IWorkLocationDAL WorkLocationDAL)
        {
            _WorkLocationDAL = WorkLocationDAL;
        }

        public void TDelete(int id)
        {
            _WorkLocationDAL.Delete(id);
        }

        public WorkLocation TGetById(int id)
        {
            return _WorkLocationDAL.GetById(id);
        }

        public List<WorkLocation> TGetList()
        {
           return _WorkLocationDAL.GetList();
        }

        public void TInsert(WorkLocation t)
        {
            _WorkLocationDAL.Insert(t);
        }

        public void TUpdate(WorkLocation t)
        {
            _WorkLocationDAL.Update(t);
        }
    }
}
