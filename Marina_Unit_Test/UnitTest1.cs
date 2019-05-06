using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software_Implementation_Project.Factory;
using Software_Implementation_Project;
using System.Collections.Generic;
using System.Linq;

namespace Marina_Unit_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BuildBoatTypesTest()
        {
            //arrange
          
            int boatType = 1;
            //act
           BoatFactory BoatFactory = new BoatFactory();
            Boat actual = BoatFactory.BuildBoat(boatType);
            //assert
            Assert.IsInstanceOfType(actual, typeof(NarrowBoat));
        }

        [TestMethod]
        public void readDataFromFile_test()
        {
            //arrange
            int expected_numberOfRecords = 3;

            //act
            FileOperations FP = new FileOperations();
            int actual = FP.readDataFromFile().Count;
        
            //assert
            Assert.AreEqual(expected_numberOfRecords, actual);

        }

        [TestMethod]
        public void deleteBooking()
        {
            //arrange
            int indexOfBoat = 1;
            int expectedRowCount = 2;
            //act
           
            MarinaMaintenanceObj MarinaMaintenance_Obj = new MarinaMaintenanceObj();
            Marina Marina = new Marina();
            FileOperations FP = new FileOperations();
            Marina._LoadDataFromFile();
            Marina.DeleteBoat(indexOfBoat);
           
         
            int actual = FP.readDataFromFile().Count;
            //assert
            Assert.AreEqual(expectedRowCount, actual);

        }

        [TestMethod]
        public void testGetMarinaCapacity()
        {
            //arrange
            int expected = 51;
            //act'
            MarinaMaintenanceObj MarinaMaintenance_Obj = new MarinaMaintenanceObj();
            Marina Marina = new Marina();
            Marina._LoadDataFromFile();
            Assert.AreEqual(expected, Marina.getCurrentCapacityMarinaLength());
        }

        [TestMethod]
        public void createBoatTest()
        {
            NarrowBoat NB = new NarrowBoat();
            
            NB.BoatDraft = 3;
            NB.BoatLength = 15;
            NB.NameOfBoat = "Phantom Menance";
            NB.NameOfOwner = "Anakin Skywalker";
            MarinaMaintenanceObj MarinaMaintenance_Obj = new MarinaMaintenanceObj();
            Marina Marina = new Marina();
          
            Marina.ClearAllMarinaItems();
            //add new boat to marina
            Marina.addBoatToMarina(NB);
            List<string> listData = new List<string>();
            listData = Marina.convertMarinaToList();
            //write to  file

            FileOperations FP = new FileOperations();
            FP.writeToFile(listData);
            int index=Marina.getCurrentCapacityMarinaLength();
            
            List<string> list = new List<string>();
            list=FP.readDataFromFile();

           
            string nameOflastBoatInList = list.Last();
            //split array at commas and put result into an array
            string[] arrSplitRow = nameOflastBoatInList.Split(",".ToCharArray());
            string actual = arrSplitRow[1];
            Assert.AreEqual(actual.ToUpper(), NB.NameOfOwner.ToUpper());

        }


        [TestMethod]
        
        public void TestDisplayMessage()
        {
            DisplayManager.displayMessage("Hello");
        }
    }
}
