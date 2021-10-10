using System;
using System.Threading;
using System.Diagnostics;



namespace reactionTimer
{
    class reactionTimer
    {
        public static long TotalTime {get;set;}
        public static int Accuracy {get;set;}
        
        static void printAsIfTyped (string Output)
        {
            var textToBeOutputted=Output;
            Random rnd = new Random();
            foreach (char c in textToBeOutputted)
            {
                Console.Write(c);
                Thread.Sleep(rnd.Next(30, 60));
            }

        }

        static int generateRandomNumber(){
             Random random = new Random();
            int randomNumber = random.Next(0, 26);

            return randomNumber;
        }

        static void initiateStartOfReactionTimer(){

            var lineOne ="\nHello and welcome to Reaction Timer!";
            var lineTwo="\nI will present you 10 random letters and measure your reaction time";
           
            printAsIfTyped(lineOne);
            Console.Clear();
            printAsIfTyped(lineTwo);
            Console.Clear();
            
            confirmStartOfReactionTimer();

        }
        static void confirmStartOfReactionTimer(){
             var lineThree="\npress any key to start!\n";
             printAsIfTyped(lineThree);
             var start =Console.ReadKey().Key.ToString();
             Console.Clear();
             outputRandomLettersAndMeasureResults();
        }

        static void outputRandomLettersAndMeasureResults(){

             for(int i = 0;i<10;i++){

                char[] alphabet = { 'A', 'B', 'C', 'D','E','F','G','H','H','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };


                int newRandomNumber = generateRandomNumber();
                Console.WriteLine(alphabet[newRandomNumber]);           
                
                var watch = new Stopwatch();  
                watch.Start();  
                char input =Console.ReadKey().KeyChar;
                char convertedInput = Char.ToUpper(input);
                
                watch.Stop(); 

                var timeElapsed = watch.ElapsedMilliseconds;
                reactionTimer.TotalTime += timeElapsed;
                if(alphabet[newRandomNumber]==convertedInput){
                    reactionTimer.Accuracy +=1;
                }
                Console.Clear();

                
            }

        }

        static void displayResults(){
            double TotalTimeInSeconds = reactionTimer.TotalTime *0.001;
            int accuracy = reactionTimer.Accuracy * 10;
            var totalTimeTaken="Total Time Taken is " + Math.Round(TotalTimeInSeconds,2) + " seconds";
            var responseTime ="\nYour Average Response Time Is " + Math.Round((TotalTimeInSeconds/10),2) + " seconds";
            var accuracyMessage = "\nYour accuracy is " + accuracy + " %" ;
            var myMessage="Made by Bilal Ahmed";
            printAsIfTyped(totalTimeTaken);
            printAsIfTyped(responseTime);
            printAsIfTyped(accuracyMessage);
            printAsIfTyped(myMessage);

           
        }
        static void Main(string[] args)
        {
            
            Console.Clear();
          
            initiateStartOfReactionTimer();
            displayResults();
        }

       

    }
}
