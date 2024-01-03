using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Orders.Comands.CreateNewOrder
{
    
    public  class CreateNewOrdervalidator:AbstractValidator<OrderItemCommand>
    {
        public CreateNewOrdervalidator()
        {
            //  RuleFor(model => model.Count).GreaterThan(10).WithMessage("hello");
            RuleFor(model => model.Items.Select(p => p.Price)).Must(x => !x.Any(x=>x==0)).WithMessage("قیمت باید بیشتر از 0 باشد");
            RuleFor(model => model.Items.Select(p => p.Count)).Must(x => !x.Any(x => x == 0)).WithMessage("تعداد وارد شده نا معتبر");
            RuleFor(model=>model.Items.Sum(x=>x.Price*x.Count)).GreaterThan(5000).WithMessage("مبلغ کل باید بیشتر 5000 باشذ");
           


        }
    }
}
