using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using QuickServiceWebApp;
using QuickServiceDAL;

namespace QuickServiceWebApp.Repository
{
    public class QuickServiceMapper<E, M>
        where E : class
        where M : class
    {
        public QuickServiceMapper()
        {

        }

        public M Translate(E obj)
        {
            return Mapper.Map<E, M>(obj);
        }
    }
}