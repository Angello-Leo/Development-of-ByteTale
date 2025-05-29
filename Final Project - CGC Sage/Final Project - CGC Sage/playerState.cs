using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project___CGC_Sage
{
    public static class PlayerState
    {
        // Player's initial spawn position
        public static int InitialX { get; set; } = 36;
        public static int InitialY { get; set; } = 33;

        // Player's "return" position (when returning from the cave)
        public static int ReturnX { get; set; } = 1296;
        public static int ReturnY { get; set; } = 683;

        // Current position of the player
        public static int X { get; set; } = InitialX;  // Start at Initial Position
        public static int Y { get; set; } = InitialY;

        // Flag to track if the player is returning from the cave
        public static bool ReturningFromCave { get; set; } = false;
        public static string Username { get; set; }

        //FOr careerPlan
        public static int CareerGuardX { get; set; }
        public static int CareerGuardY { get; set; }
        public static bool ReturningFromCareerResults { get; set; } = false;

        //for typing game
        public static int typingGuardX { get; set; }
        public static int typingGuardY { get; set; }
        public static bool ReturningFromTypingGame { get; set; } = false;
    }
}
