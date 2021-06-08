using CATlinBE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CATlinBE.DataAccessLayer.Interfaces
{
    public interface IImageDAL
    {
        Image GetImageById(long id);
    }
}
