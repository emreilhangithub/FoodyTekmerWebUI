using FoodyTekmerBusinessLayer.Abstract;
using FoodyTekmerDataAccessLayer.Abstract;
using FoodyTekmerEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTekmerBusinessLayer.Concrete
{
    public class ProductMenager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductMenager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TAdd(Product entity)
        {
            if(entity.Name != "" && entity.Name.Length <=3 && entity.NewPrice > 0)
            {
                _productDal.Add(entity);
            }
            else
            {
                //hata mesajı
            }            
        }

        public void TDelete(int id)
        {
            if(id != 0)
            {
                _productDal.Delete(id);
            }
            else
            {
               //hata mesajı
            }
           
        }

        public List<Product> TGetAllList()
        {
            return _productDal.GetAllList();
        }

        public Product TGetById(int id)
        {
           return _productDal.GetById(id);
        }

        public void TUpdate(Product entity)
        {
            if (entity.ProductId != 0 && entity.Name != "" && entity.Name.Length <= 3 && entity.NewPrice > 0)
            {
                _productDal.Update(entity);
            }
            else 
            {
                //hata mesajı
            }

        }
    }
}
