using System.Collections.Generic;
using Xunit;
using System;


namespace Slapshot.Objects
{
  public class TeamTest : IDisposable
  {
    public void Dispose()
    {
      Team.DeleteAll();
    }


    public TeamTest()
   {
     DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=slapshot_hockey_test;Integrated Security=SSPI;";
   }


   [Fact]
   public void Test1_GetTeamName()
   {

     Team newTeam = new Team("The Goons",1);

     string result = newTeam.GetTeamName();

     Assert.Equal("The Goons", result);
   }


   [Fact]
   public void Test2_GetTeamID()
   {

    Team newTeam = new Team("Leafs",1);

     int result = newTeam.GetTeam_Id();

     Assert.Equal(1, result);

   }

   [Fact]
   public void Test3_SetTeamName()
   {

     Team newTeam = new Team("Red Wings",1);
     newTeam.SetName("Red Wings");

     string result = newTeam.GetTeamName();

     Assert.Equal("Red Wings", result);
   }




   [Fact]
   public void Test4_SaveTeamName()
   {

   Team newTeam = new Team("Red Wings",1);
   newTeam.Save();

   List<Team> allTeams = Team.GetAll();
   Console.WriteLine(allTeams.Count);

   Assert.Equal(newTeam, allTeams[0]);
   }



     [Fact]
     public void Test5_FindTeamId()
     {
       Team newTeam = new Team ("Leafs",1);
       newTeam.Save();

       Team findTeam = Team.Find(newTeam.GetId());

       Assert.Equal(findTeam, newTeam);
     }



     [Fact]
  public void Test6_UpdateTeam()
  {
    Team newTeam = new Team("Avalanche",1);
    newTeam.Save();
    newTeam.Update("Bruins");
    string result = newTeam.GetTeamName();

    Assert.Equal("Bruins", result);
  }



     [Fact]
     public void Test7_DeleteOneTeam()
     {
       Team firstTeam = new Team("BlackHawks",1);
       firstTeam.Save();

       Team secondTeam = new Team("Rangers",1);
       secondTeam.Save();

       firstTeam.Delete();
       List<Team> allTeams = Team.GetAll();
       List<Team> afterDeleteFristTeam = new List<Team> {secondTeam};

       Assert.Equal(afterDeleteFristTeam, allTeams);
     }


 }
}
