
using NasaExplorer.Entity;
Console.ForegroundColor = ConsoleColor.DarkCyan;

try
{
    LandData landData = new LandData();
    DataNavigation dataNavigation = new DataNavigation();
    NasaRover MarsRover = new NasaRover();
    

// Declare variables and then initialize to zero.
    int flagValidation = 0;
    string? Boundaries = String.Empty;
    string? InitianPosition = String.Empty;
    string? RoadmapComands = String.Empty;

    Console.Clear();
    Console.Title = "Sales Taxes App";
    Console.WriteLine("Welcome to Nasa Explorer APP!");
    Console.WriteLine("##########################");

    #region Insert boundary parameters
    //##### validating correct format for curent position
    flagValidation = 0;
    while ((Boundaries.Length != 2))
    {
        if(flagValidation >= 1)
            Console.WriteLine("Error in boundaries. Try in the correct format");
        else if (flagValidation > 3)
        {
            Console.WriteLine("You exceeded the allowed attempt. The program will finish.");
            Environment.Exit(99);
        }
        
        Console.WriteLine("Insert Boundary [XY] (X:0-9, Y:0-9), and then press Enter...");
        Boundaries = Convert.ToString(Console.ReadLine());
        flagValidation += 1;

    }
    landData.MinX = 0;
    landData.MinY = 0;
    landData.MaxX = Convert.ToInt32(Boundaries[0].ToString());
    landData.MaxY = Convert.ToInt32(Boundaries[1].ToString());
    #endregion Insert boundary parameters

    var flagNewRoute = 0;
    while (flagNewRoute != -1)
    {
        
        #region Insert initial position Rover
        //##### validating correct format for curent position
        flagValidation = 0;
        InitianPosition = "";
        while ((InitianPosition.Length != 3))
        {
            if(flagValidation >= 1)
                Console.WriteLine("Error in current position. Try in the correct format");
            else if (flagValidation > 3)
            {
                Console.WriteLine("You exceeded the allowed attempt. The program will finish.");
                Environment.Exit(99);
            }
        
            Console.WriteLine("Insert current position Rover [XYC] (X:0-9, Y:0-9, C: N,S,E,W), and then press Enter..");
            InitianPosition = Convert.ToString(Console.ReadLine());
            flagValidation += 1;

        }
        dataNavigation.CoordinateX = Convert.ToInt32(InitianPosition[0].ToString());
        dataNavigation.CoordinateY = Convert.ToInt32(InitianPosition[1].ToString());
    
        //##### validating current position is inside of boundaries of land
        flagValidation = 0;
        while (!landData.IsCurrentPositionInsideBoundaries(dataNavigation))
        {
            if (flagValidation > 3)
            {
                Console.WriteLine("You exceeded the allowed attempt. The program will finish.");
                Environment.Exit(99);
            }

            Console.WriteLine("The initial position is out of boundaries. Insert a valid initial position and then press Enter..");
            Console.WriteLine("Insert current position Rover [XYC] (X:0-9, Y:0-9, C: N,S,E,W), and then press Enter..");
            InitianPosition = Convert.ToString(Console.ReadLine());
            dataNavigation.CoordinateX = Convert.ToInt32(InitianPosition[0].ToString());
            dataNavigation.CoordinateY = Convert.ToInt32(InitianPosition[1].ToString());
            flagValidation += 1;
        
        }
        //Facing initial direction
        dataNavigation.SetFacingDirectionFromString(InitianPosition[2].ToString());
        #endregion Insert initial position Rover

        #region Insert instructions for Rover route
        // Ask move instructions
        RoadmapComands = "";
        Console.WriteLine("Insert Rover route instructions with the following options:");
        Console.WriteLine("L - Turn left");
        Console.WriteLine("R - Turn right");
        Console.WriteLine("M - Move ");
        Console.Write("Write all instructions in a line like this: LMLMLMLMM --> ");

        RoadmapComands = Convert.ToString(Console.ReadLine()).ToUpper();
        bool validInstructions = dataNavigation.InstructionsAreValid(RoadmapComands);

        // Evaluating instructions
        if (!validInstructions)
        {
            Console.WriteLine("Some instructions are invalid. These will be skipped. press Enter...");
            Console.ReadLine();

        }
        #endregion Insert instructions for Rover route

        #region Processing the instructions
        foreach (char instruction in RoadmapComands)
        {
            if (instruction.ToString() == "L"
                || instruction.ToString() == "R")
            {
            
                MarsRover.Turn90(dataNavigation, instruction.ToString());
            }
            if (instruction.ToString() == "M")
            {
                MarsRover.MoveFordward(dataNavigation);
            }
            //if you want to check step by step route
            /*Console.WriteLine("Current Position (X,Y):{0},{1} Facing Direction:{2} ", dataNavigation.CoordinateX, 
                                                                        dataNavigation.CoordinateY, 
                                                                        dataNavigation.FacingDirection);*/
        }
    
        Console.WriteLine("#### The final MarsRover position is: [{0} {1} {2}] ####", dataNavigation.CoordinateX, 
            dataNavigation.CoordinateY, 
            dataNavigation.FacingDirection.ToString()[0]);

        #endregion Processing the instructions

        flagNewRoute += 1;
        if (flagNewRoute >= 1)
        {
            Console.WriteLine("....");
            Console.WriteLine("....");
            Console.WriteLine("Do you want to set another route? [Y/N] ");
            if (Console.ReadLine().ToUpper() != "Y")
            {
                Console.WriteLine("....");
                Console.WriteLine("....");
                Console.Write("Thanks for use the Nasa Explorer route service...");
                Environment.Exit(0);
            }
        }
        
        Console.Clear();
    }
    
}
catch (Exception ex)
{
    
}

