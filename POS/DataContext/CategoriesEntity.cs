using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_category")]
    public class CategoriesEntity
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }

        [Required]
        [Column("category_name")]
        public String CategoryName { get; set; }

        [Required]
        [Column("description")]
        public String Description { get; set; }

        [Required]
        [Column("picture")]
        public String Picture { get; set; }

        public ICollection<ProductsEntity> Products { get; set; }

        public CategoriesEntity(POS.ViewModel.CategoryModel model)
        {
                CategoryName= model.CategoryName;
                Description= model.Description;
                Picture= model.Picture;
        }

        public CategoriesEntity()
        {

        }
    }
}
