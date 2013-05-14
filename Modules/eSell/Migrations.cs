using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace eSell {
    public class Migrations : DataMigrationImpl {

        public int Create() {
			// Creating table ProductPartRecord
			SchemaBuilder.CreateTable("ProductPartRecord", table => table
				.ContentPartRecord()
				.Column("Price", DbType.Single)
				.Column("Discount", DbType.Single)
			);

            return 1;
        }

        public int UpdateFrom1()
        {
            ContentDefinitionManager.AlterPartDefinition("ProductPart",
              builder => builder.Attachable());
            return 2;
        }

        public int UpdateFrom2() 
        {
            ContentDefinitionManager.AlterPartDefinition("ProductPart",
                builder => builder.Attachable().WithField("ProductImage",
                    fieldBuilder => fieldBuilder
                        .OfType("MediaPickerField")
                        .WithDisplayName("Product Image")));
            
            ContentDefinitionManager.AlterTypeDefinition("Product",
                d => d.WithPart("TitlePart")
                    .WithPart("CommonPart", p => p
                        .WithSetting("DateEditorSettings.ShowDateEditor", "true"))
                    .WithPart("ProductPart")
                    .WithPart("BodyPart")
                    .WithPart("ContainablePart")
                    .WithPart("AutoroutePart")
            );

            return 3;
        }

        public int UpdateFrom3()
        {
            ContentDefinitionManager.AlterTypeDefinition("Product",
                d => d.WithPart("AutoroutePart",
                    part=>part.WithSetting("AutorouteSettings.AllowCustomPattern", "true")
                        .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "false")
                        .WithSetting("AutorouteSettings.PatternDefinitions",@"[{Name:'title',Pattern:'{Content.ContentType}/{Content.Slug}',Description:'product/title'}]")
                        .WithSetting("AutorouteSettings.DefaultPatternIndex", "0"))
            );

            return 4;
        }

        public int UpdateFrom4() 
        {
            ContentDefinitionManager.AlterTypeDefinition("Product",
                d => d.WithPart("CommonPart", p => p
                        .WithSetting("DateEditorSettings.ShowDateEditor", "true")));
            return 5;
        }

        public int UpdateFrom5()
        {
            ContentDefinitionManager.AlterPartDefinition("ProductPart",
                builder => builder.Attachable().WithField("Category",
                    fieldBuilder => fieldBuilder
                        .OfType("TaxonomyField")
                        .WithDisplayName("Catalog Category")));
            return 6;
        }
    }
}