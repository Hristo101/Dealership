using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Infrastructure.Common.Constants
{
    public static class DataConstant
    {
        public static class Car
        {
            public const int MakeMaxLength = 50;
            public const int MakeMinLength = 2;

            public const int ModelMaxLength = 50;
            public const int ModelMinLength = 2;

            public const int ColorMaxLength = 50;
            public const int ColorMinLength = 2;

            public const int EngineTypeMaxLength = 250;
            public const int EngineTypeMinLength = 1;

            public const int SpeedsMaxLength = 1000;
            public const int SpeedsMinLength = 1;

            public const int YearMinValue = 2002;
            public const int YearMaxValue = 9999;

            public const int MinCarImagesCount = 4;
        }

        public static class Announcement
        {
            public const int DescriptionMinLength = 1;
            public const int DescriptionMaxLength = 1000; 

            public const double PriceMinValue = 0.01;
            public const double PriceMaxValue = 1_000_000; 

            public const string DefaultStatus = "Approved";
        }

        public static class Comment
        {
            public const int ContentMinLength = 5;
            public const int ContentMaxLength = 500;

            public const int GradeMinValue = 1;
            public const int GradeMaxValue = 5; 
        }

        public static class Query
        {
            public const int MessageMinLength = 1;
            public const int MessageMaxLength = 1000; 

            public const int AdminResponseMaxLength = 1000; 
        }
    }

}
