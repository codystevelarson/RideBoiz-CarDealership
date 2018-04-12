using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class VehicleVM
    {
        public Vehicle Vehicle { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<SelectListItem> MakeList { get; set; }
        public List<SelectListItem> ModelList { get; set; }
        public List<SelectListItem> ColorList { get; set; }
        public List<SelectListItem> InteriorList { get; set; }
        public List<SelectListItem> BodyStyle { get; set; }
        public List<SelectListItem> Transmissions { get; set; }

        //[RegularExpression(@".*\.(jpg|jpeg|png)$", ErrorMessage = "File must be .jpg, .jpeg, or .png")]
        public HttpPostedFileBase VehicleImage { get; set; }


        public VehicleVM()
        {
            MakeList = new List<SelectListItem>();
            ModelList = new List<SelectListItem>();
            ColorList = new List<SelectListItem>();
            InteriorList = new List<SelectListItem>();
            BodyStyle = new List<SelectListItem>();
            Transmissions = new List<SelectListItem>();
        }

        public void SetMakeListItems(List<Make> makes)
        {
            foreach (var make in makes)
            {
                MakeList.Add(new SelectListItem()
                {
                    Value = make.MakeId.ToString(),
                    Text = make.MakeName
                });
            }
        }

        public void SetModelListItems(List<CarModel> models)
        {
            foreach (var model in models)
            {
                ModelList.Add(new SelectListItem()
                {
                    Value = model.ModelId.ToString(),
                    Text = model.ModelName
                });
            }
        }

        public void SetColorListItems(List<Color> colors)
        {
            foreach (var color in colors)
            {
                ColorList.Add(new SelectListItem()
                {
                    Value = color.ColorId.ToString(),
                    Text = color.ColorName
                });
            }
        }

        public void SetInteriorListItems(List<Interior> interiors)
        {
            foreach (var interior in interiors)
            {
                InteriorList.Add(new SelectListItem()
                {
                    Value = interior.InteriorId.ToString(),
                    Text = interior.InteriorName
                });
            }
        }


        public void SetSingleMakeAndModelListItem(CarModel model)
        {
            ModelList.Add(new SelectListItem()
            {
                Value = model.ModelId.ToString(),
                Text = model.ModelName
            });

            MakeList.Add(new SelectListItem()
            {
                Value = model.Make.MakeId.ToString(),
                Text = model.Make.MakeName
            });
        }
    }
}
