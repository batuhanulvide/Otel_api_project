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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDAL _TestimonialDAL;

        public TestimonialManager(ITestimonialDAL TestimonialDAL)
        {
            _TestimonialDAL = TestimonialDAL;
        }

        public void TDelete(int id)
        {
            _TestimonialDAL.Delete(id);
        }

        public Testimonial TGetById(int id)
        {
            return _TestimonialDAL.GetById(id);
        }

        public List<Testimonial> TGetList()
        {
           return _TestimonialDAL.GetList();
        }

        public void TInsert(Testimonial t)
        {
            _TestimonialDAL.Insert(t);
        }

        public void TUpdate(Testimonial t)
        {
            _TestimonialDAL.Update(t);
        }
    }
}
