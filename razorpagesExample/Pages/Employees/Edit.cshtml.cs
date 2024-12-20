using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using razorpagesExample.Models;
using razorpagesExample.Repository;

namespace razorpagesExample.Pages.Employees;

    public class EditModel : PageModel
    {      
        private readonly IEmployeeRepository _employeeRepository;
        public EditModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [BindProperty]
        public Employee Employee { get; set; } = null!;
        public void OnGet(int id)
            {
                Employee = _employeeRepository.GetById(id);

                if (Employee == null)
                {
                    // Employee bulunamadığında yapılacak işlem
                    // Örneğin, bir hata mesajı gösterilebilir veya başka bir sayfaya yönlendirebilirsiniz.
                    RedirectToPage("/NotFound");
                }
            }

        // public IActionResult OnPost(Employee employee)
        // {
        //     Employee = _employeeRepository.Update(employee);
        //     return RedirectToPage("/Employees/Index");
        // }
        public IActionResult OnPost()
        {
            Employee = _employeeRepository.Update(Employee);
            return RedirectToPage("/Employees/Index");
        }

    }
