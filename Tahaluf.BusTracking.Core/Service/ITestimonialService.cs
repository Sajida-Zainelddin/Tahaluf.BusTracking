﻿using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;

namespace Tahaluf.BusTracking.Core.Service
{
    public interface ITestimonialService
    {
        List<Test> GetAllTestimonials();

        bool CreateTestimonial(Test testimonial);

        bool UpdateTestimonial(testUpdateDTO testimonial);

        string DeleteTestimonial(int id);

        List<Testimonialstatus> GetTestimonialStatus();
    }
}
