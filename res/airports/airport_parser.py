import csv
import requests

CSV = 'https://raw.githubusercontent.com/jpatokal/openflights/master/data/airports.dat'
CSV2 = 'https://raw.githubusercontent.com/datasets/airport-codes/master/data/airport-codes.csv'
us_list = []
needs_iata = {}
no_use = ['heliport', 'closed', 'seaplane_base']

with requests.Session() as s:
	download = s.get(CSV)

	decoded = download.content.decode('utf-8')

	cr = csv.reader(decoded.splitlines(), delimiter=',')
	airport_list = list(cr)
	for row in airport_list:
		if row[3] == 'United States':
			if row[4] != '\\N':
				us_list.append(row)
			else:
				needs_iata[row[5]] = row

print('us list = {}'.format(len(us_list)))

with requests.Session() as s:
	download = s.get(CSV2)

	decoded = download.content.decode('utf-8')

	cr = csv.reader(decoded.splitlines(), delimiter=',')
	airport_list = list(cr)
	for row in airport_list:
		# if row[7] == 'US' and row[1] not in no_use and row[11]:
		if row[0] in needs_iata and row[11]:
			needs_iata[row[0]][4] = row[11]
			us_list.append(needs_iata[row[0]])	

			
with open("us_airports.csv", "w", newline='') as f:
	writer = csv.writer(f)
	writer.writerows(us_list)

print('us list = {}'.format(len(us_list)))
