import sys

file_name = sys.argv[1]
if not file_name:
	sys.exit("Usage: python script.py filename.txt")

with open(file_name, "r") as f:
	output = open("output.txt", "w")
	for line in f:
		entry = line.split(",")[0]
		output.write(entry + " = int.Parse(data[(int)CreatureTemplateColumn." + entry + "]),\n")