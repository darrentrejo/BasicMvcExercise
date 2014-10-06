using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using ProgrammingExercise.Domain.Entities;
using ProgrammingExercise.Domain.Abstract;
using Moq;
using ProgrammingExercise.Domain.Concrete;

namespace ProgrammingExercise.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            //Bindings go here
            //Mock<IShoppingBasketRepository> mock = new Mock<IShoppingBasketRepository>();
            //mock.Setup(m => m.LineItems).Returns(new List<LineItem>
            //{
            //    new LineItem {
            //        Quantity = 1,
            //        Product = new Product {
            //            Name = "Book",
            //            Price = 12.49M,
            //            ImportDutyCode = new ImportDutyCode {
            //                Rate = 0.0M
            //            },
            //            Category = new Category {
            //                SalesTaxCode = new SalesTaxCode {
            //                    Rate = 0.0M
            //                }
            //            }
            //        }
            //    },
            //    new LineItem {
            //        Quantity = 1,
            //        Product = new Product {
            //            Name = "Music CD",
            //            Price = 14.99M,
            //            ImportDutyCode = new ImportDutyCode {
            //                Rate = 0.0M
            //            },
            //            Category = new Category {
            //                SalesTaxCode = new SalesTaxCode {
            //                    Rate = 10.0M
            //                }
            //            }
            //        }
            //    },
            //    new LineItem {
            //        Quantity = 1,
            //        Product = new Product {
            //            Name = "Chocolate Bar",
            //            Price = 0.85M,
            //            ImportDutyCode = new ImportDutyCode {
            //                Rate = 0.0M
            //            },
            //            Category = new Category {
            //                SalesTaxCode = new SalesTaxCode {
            //                    Rate = 0.0M
            //                }
            //            }
            //        }
            //    }
            //}.AsQueryable());

            //ninjectKernel.Bind<IShoppingBasketRepository>().ToConstant(mock.Object);

            ninjectKernel.Bind<IShoppingBasketRepository>().To<EFShoppingBasketRepository>();
        }
    }
}