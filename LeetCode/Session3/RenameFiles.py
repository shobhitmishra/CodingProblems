import os
path = "D:\Bot Framework\BotBuilder-Samples\samples\csharp_dotnetcore"


subfolders = [f for f in os.scandir(path) if f.is_dir()]
for subFolder in subfolders:
    files = [file for file in os.scandir(subFolder.path) if file.name.endswith(".csproj")]    
    for file in files:
        number = subFolder.name[0:2]        
        src = file.path
        name = file.name
        newName = subFolder.path + "\\" + number + "." + name
        print(newName)
        os.rename(src, newName)



