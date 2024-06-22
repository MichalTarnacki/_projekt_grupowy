using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ResearchCruiseApp_API.Data.Classes
{


    public static class Constants
    {
        public static int DefaultPoints = 0;

        public static  int BaThesis = 0;
        public static  int BaThesisPoints = 20;
        
        public static  int MScThesis = 1;
        public static  int MScThesisPoints = 50;

        public static  int PhDThesis = 2;
        public static  int PhDThesisPoints = 100;

        public static  int ScOrRdProject = 3;
        public static  int ScOrRdProjectFinancingApprovedPoints = 100;
        public static  int ScOrRdProjectFinancingNotApprovedPoints = 150;
  
        public static  int DomesticProject = 4;
        public static  int DomesticProjectPoints = 50;
        public static  float DomesticProjectPointsRatio = 1 / 100000;
  
        public static  int ForeignProject = 5;
        public static  int ForeignProjectPoints = 80;
        public static  float ForeignProjectPointsRatio = 1 / 100000;
  
        public static  int InternalProject = 6;
        public static  int InternalProjectPoints = 30;
  
        public static  int CommercialProject = 7;
  
        public static  int DidacticsProject = 8;
  
        public static  int OwnProjectRealizationProject = 9;
        public static  int OwnProjectRealizationPoints = 100;
  
        public static  int OtherProject = 10;
  
        public static  string DomesticContract = "domestic";
        public static  int DomesticContractPoints = 150;
  
        public static  string ForeignContract = "foreign";
        public static  int ForeignContractPoints = 300;
  
        public static  int UgTeamPointsFromAtLeast3Units = 100;
        public static  int UgTeamPointsFromAtLeast2Units = 50;
          
        public static  string DefaultPublication = "subject";
        public static  float DefaultPublicationPointRatio = 0.5f;
  
        public static  string PublicationFromRV = "postscript" ;
        public static  float PublicationFromRVPointRatio = 1;
  
        public static  int SpubTaskPoints = 100;
    }  
}  