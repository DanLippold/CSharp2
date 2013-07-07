using CruiseControl.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CruiseControl.Models
{
    public class BoardStatus
    {
        // Board properties
        public int RoundNumber { get; set; }
        public VesselStatus[] VesselStatuses { get; set; }
        public Coordinate[] ReportedDamageCoordinates { get; set; }
        public Coordinate[] PowerUpCoordinates { get; set; }
        public int[] PlayerIdsOfRecentlySunkVessels { get; set; }
        public int ActiveVesselCount { get; set; }
        public int SunkVesselCount { get; set; }
        public Coordinate BoardMinCoordinate { get; set; }
        public Coordinate BoardMaxCoordinate { get; set; }
        public int TurnsUntilBoardShrink { get; set; }

        // Player specific properties
        public List<Coordinate> HitCoordinates { get; set; }
        public List<Coordinate> MissCoordinates { get; set; }
        public List<VesselStatus> MyVesselStatuses { get; set; }
        public List<PowerUpType> MyPowerUps { get; set; }
    }
}