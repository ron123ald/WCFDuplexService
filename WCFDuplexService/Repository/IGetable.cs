﻿
using System.Collections.Generic;
namespace WCFDuplex.Repository
{
    public interface IGetListable<T> where T : class
    {
        List<T> GetList(object arg);
    }
}
