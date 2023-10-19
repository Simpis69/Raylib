using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(800, 600, "Hello");
Raylib.SetTargetFPS(60);

int floorY = 550;
int floorSpeedY = -1;
Vector2 position = new Vector2(400, 300);
Vector2 movement = new Vector2(10, 10);

Color hotPink = new Color(255, 105, 180, 255);

Texture2D characterImage = Raylib.LoadTexture("smil.png");
Rectangle characterRect = new Rectangle(10, 10, 32, 32);
characterRect.width = characterImage.width;
characterRect.height = characterImage.height;

string scene = "start";



while (!Raylib.WindowShouldClose())
{


    // --------------------------------------------------------------------------------------------------------------------------------
    // GAME LOGIC
    // --------------------------------------------------------------------------------------------------------------------------------

    if(scene == "start")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
        {
            scene = "game";
        }
    }
    else if(scene == "game")
    {
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
    {
        characterRect.x -= movement.X;
    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
    {
        characterRect.x += movement.X;
    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
    {
        characterRect.y -= movement.Y;
    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
    {
        characterRect.y += movement.Y;
    }




    floorY += floorSpeedY;
    if (floorY < 0)
    {
        floorSpeedY = 1;
    }
    else if (floorY > 550)
    {
        floorSpeedY = -1;
    }
    }

    // --------------------------------------------------------------------------------------------------------------------------------
    // RENDERING
    // --------------------------------------------------------------------------------------------------------------------------------






    Raylib.BeginDrawing();

    if (scene == "start")
    {
        Raylib.ClearBackground(Color.SKYBLUE);
        Raylib.DrawText("press SPACE to begin", 10, 10, 32, Color.BLACK);
    }

    else if (scene == "game")
    {

        Raylib.ClearBackground(Color.DARKGREEN);

        Raylib.DrawRectangleRec(characterRect, Color.BLUE);


        Raylib.DrawRectangle(0, floorY, 800, 30, Color.BROWN);

        Raylib.DrawTexture(characterImage, (int)characterRect.x, (int)characterRect.y, Color.WHITE);
    }

    Raylib.EndDrawing();
}