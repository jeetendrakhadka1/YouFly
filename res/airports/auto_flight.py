import csv
from faker import Faker

fake = Faker()

flights = [['AirportStart_FK', 'AirportEnd_FK', 'FlightDate', 'FlightTime', 'NumFCSeats', 'FCSeatPrice', 'NumBusSeats', 'BusSeatPrice']]

some_iata_codes = ['MSY', 'HOU', 'BOS', 'MIA', 'ORL', 'JFK', 'LAX', 'ORD', 'BTR', 'ATL', 'MDW', 'AUS']

def generate_flights():
	print('...generating flights...')
	for iata in some_iata_codes:
		for another in some_iata_codes:
			if another != iata:
				dt = fake.date_time_this_year(before_now=False, after_now=True, tzinfo=None)
				flight_date = dt.date()
				flight_time = dt.time()
				flights.append([iata, another, flight_date.isoformat(), flight_time.isoformat(), 100, 150, 200, 125])
	print('Flight count: {}', len(flights))

generate_flights()
generate_flights()

with open("random_flights.csv", "w", newline='') as f:
	writer = csv.writer(f)
	writer.writerows(flights)

print(len(flights))
print(flights[5])
