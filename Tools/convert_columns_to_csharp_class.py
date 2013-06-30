import sys

file_name = sys.argv[1]
if not file_name:
	sys.exit("Usage: python convert_columns_to_csharp.py filename.txt")

with open(file_name, "r") as f:
	output = open("output.txt", "w")
	for line in f:
		columns = line.split(",")
		for column in columns:
			output.write("public int "+column+" { get; set; }\n")