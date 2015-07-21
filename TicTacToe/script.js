 
            function Start()
            {
                turn="X";   //its a global variable. to make it local we could have used var wit it
                won = false;
                SetMessage(turn + " 's turn");
            }
            function SetMessage(message1)
            {
                document.getElementById("message").innerText = message1;
                
            }

            function nextMove(Square)
            {
                if (won==true)
                    SetMessage(turn + " wins !\nCONGRATULATIONS");

                else if (Square.innerText == "") {
                    Square.innerText = turn;
                    switchTurn();
                    SetMessage(turn + " 's turn");
                }
                else
                    SetMessage("that box already filled");

            }

            function switchTurn()
            {
                if (checkForWinner(turn))
                {
                    SetMessage(turn + " wins !\nCONGRATULATIONS");
                    won = true;
                                           
                }
                else if (turn == "X")
                    turn = "O";
                else
                    turn = "X"
            }
            function checkForWinner(move)
            {
                var result=false;
                if (checkRow(1, 2, 3, move) ||
                    checkRow(4, 5, 6, move) ||
                    checkRow(7, 8, 9, move) ||
                    checkRow(1, 4, 7, move) ||
                    checkRow(2, 5, 8, move) ||
                    checkRow(3, 6, 9, move) ||
                    checkRow(1, 5, 9, move) ||
                    checkRow(3, 5, 7, move))
                    result = true;
                return result;
            }
            
            function checkRow(box1,box2,box3,move)
            {
                var result = false;
                if (getBox(box1) == move && getBox(box2) == move && getBox(box3) == move)
                    result = true;
                return result;

            }

            function getBox(number)
            {
                return document.getElementById("s"+number).innerText;
            }
       
        