using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CRUD.Model.PersonModel;

namespace CRUD
{
    interface IForm1
    {
        void CreateFunction(CreateModel create);
        void UpdateFunction(UpdateModel update);
        void DeleteFunction(DeleteModel delete);
    }
}
