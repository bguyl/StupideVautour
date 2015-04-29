using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StupidVulture.GameCore.Players;
using StupidVulture.GameCore.Cards;

namespace StupidVulture.GameCore {


    public class Engine {

        private List<Player> players;
        private int nbPlayers;
        private List<PointCard> stack;
        private PointCard currentCard = null; //The mouse or the vulture who is currently in play
        private const int nbMice = 10;
        private const int nbVultures = 5;
        

        public List<PointCard> Stack {
            get { return stack; }       
        }

        /// <summary>
        /// Public constructor 
        /// </summary>
        /// <param name="players">List of players</param>
        public Engine(List<Player> players) {
            this.players = players;
            nbPlayers = this.players.Count();
            this.stack = new List<PointCard>();
            initializeCards();
        }

        public List<Player> Players {
            get { return players; }
        }
        
        public int amountPlayers {
            get { return nbPlayers; }
            set { nbPlayers = value; }
        }
        
        /// <summary>
        /// Shuffle randomly the Cards;
        /// </summary>
        public void shuffleCards() {
            Random rand = new Random();
            for(int i = stack.Count()-1; i >= 0;i--) {
                int k = rand.Next(i+1);
                PointCard temp = stack[k];
                stack[k] = stack[i];
                stack[i] = temp;
            }
        }


        /// <summary>
        /// Initilize the stack with the mice ant the vultures and then suffle the stuck
        /// </summary>
        public void initializeCards() {
            for(int i = 1;i <= nbMice;i++) {
               stack.Add(new PointCard(CardType.Mouse,i));
            }
            for(int j = -1; j >= (0-nbVultures); j--) {
                stack.Add(new PointCard(CardType.Vulture, j));
            }
            shuffleCards();
        }


        /// <summary>
        /// Test if the game is over or not
        /// </summary>
        /// <returns></returns>
        public Boolean endingTest() {
            if (stack.Count() == 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Draw the first card of the shuffled stack.
        /// </summary>
        /// <returns></returns>
        public PointCard DrawCard() {
            currentCard = stack[0];
            stack.Remove(currentCard);
            return currentCard;
        }



        /// <summary>
        /// Call play() method for each players
        /// </summary>
        /// <returns>Winner of this turn</returns>
        public Player play() {          
            for(int i = 0;i < nbPlayers; i++) {
                players[i].play(currentCard);
            }
            Player winner = turnWinner(players);
            if(winner != null)
                incrementWinnerScore(winner);
            return winner;
        }

        public void incrementWinnerScore(Player winner) {
            winner.Score += currentCard.Value;
        }


        /// <summary>
        /// Find the winner of the current turn
        /// </summary>
        /// <param name="players">List of all players</param>
        /// <returns></returns>
        public Player turnWinner(List<Player> players) {
            int min = 16, max = 0;
            List<Player> playmin, playmax;
            playmin = new List<Player>(); //List of the players who played the minimum value
            playmax = new List<Player>();// List of the players who played the maximum value
            for(int i=0; i < players.Count();i++) { 
                //for each players, if the current player has a smaller value than the previous minimum, he becomes
                //the new minimum
                if (players[i].CurrentPlayerCard.Value < min) {
                    playmin.Clear();
                    playmin.Add(players[i]);
                    min = players[i].CurrentPlayerCard.Value;
                }
                //if the current player has the same value as the previous minimum, he's added to the minimum list
                else if (players[i].CurrentPlayerCard.Value == min) {
                    playmin.Add(players[i]);
                }
                //for each players, if the current player has a higher value than the previous maximum, he becomes
                //the new maximum
                if (players[i].CurrentPlayerCard.Value > max) {
                    playmax.Clear();
                    playmax.Add(players[i]);  
                    max = players[i].CurrentPlayerCard.Value;
                }
                //if the current player has the same value as the previous maximum, he's added to the maximum list
                else if(players[i].CurrentPlayerCard.Value == max) {
                    playmax.Add(players[i]);
                }
            }

            //a new list of players is build without the players who played the same value
            List<Player> players2 = new List<Player>(players);
            //if it's a mice but there are several players in the maximum list, they are removed from the list and 
            //the fonction is called again on this new list
            if (currentCard.Type == CardType.Mouse && playmax.Count() > 1) {
                foreach (Player player in playmax) {
                    players2.Remove(player);
                }
                return turnWinner(players2);
            }
                //if it's a vulture but there are several players in the minimum list, they are removed from the list and
                //the fonction is called again on this new list
            else if (currentCard.Type == CardType.Vulture && playmin.Count() > 1) {
                foreach (Player player in playmin) {
                    players2.Remove(player);
                }
                return turnWinner(players2);
            }
            //if it's a mice and there is a single player in the maximum list, he's the winner
            else if (currentCard.Type == CardType.Mouse && playmax.Count() == 1) {
                return playmax[0];
            }
            //if it's a vulture and there is a single player in the minimum list, he's the loser 
            else if (currentCard.Type == CardType.Vulture && playmin.Count() == 1) {
                return playmin[0];
            }
            else
                return null;
        }


        /// <summary>
        /// Find the winner of the game
        /// </summary>
        /// <returns></returns>
        public List<Player> getWinner() {
            int max = -1;
            List<Player> winners = new List<Player>();
            foreach(Player player in players) {
                if(player.Score > max) {
                    winners.Clear();
                    winners.Add(player);
                    max = player.Score;
                }
                else if(player.Score == max) {
                    winners.Add(player);
                }
            }
            return winners;
        }
    }
}
