using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using QuickServiceDAL;


namespace QuickServiceWebAPI.Repository
{
    public class QuickServiceMapper<E, M>
        where E : class
        where M : class
    {
        public QuickServiceMapper()
        {
            Mapper.CreateMap<StaffDetail, Models.StaffDetail>();
            Mapper.CreateMap<Models.StaffDetail, StaffDetail>();
        }

        public M Translate(E obj)
        {
            return Mapper.Map<E, M>(obj);
        }
    }
}