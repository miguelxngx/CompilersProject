production = 1
with open("grammar.txt", "r") as input_file:
    with open("results.txt", "w+") as output:
        for line in input_file:
            line = line[:-1]
            lineElements = line.split(" ")
            head = lineElements[0]
            body = []
            for i in range(2, len(lineElements)):
                body.append(lineElements[i])
            output.write("productions.Add(\""+str(production)+"\", new Production(\""+head+"\", new string[] {")
            for element in body:
                output.write("\""+element+"\", ")
            output.write("}));\n")
            production += 1
            