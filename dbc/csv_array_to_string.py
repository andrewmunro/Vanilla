import csv

with open('CharStartOutfit.csv', 'rb') as csvfile:
	data = csv.reader(csvfile, delimiter=' ', quotechar='|')
	for row in data:
		print(row)
		print("end")
		columns = row[0].split(",")
		print columns