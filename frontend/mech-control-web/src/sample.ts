import {
    Customer,
    CustomerType
} from './types';

const customers: Customer[] = [
    {
        id: 'cust001',
        firstName: 'John',
        lastName: 'Doe',
        fullName: 'John Doe',
        email: 'john.doe@example.com',
        phone: '+1234567890',
        address: {
            street: '123 Main St',
            number: '456',
            neighborhood: 'Downtown',
            city: 'Springfield',
            stateCode: 'SP',
            zipCode: '12345',
            countryCode: 'US',
            complement: 'Apt 1',
            reference: 'Near Central Park'
        },
        type: CustomerType.Individual,
        mechShopId: 'shop001',
        document: 'AB123456',
        createdOnUtc: new Date('2022-01-01T00:00:00Z'),
        modifiedOnUtc: new Date('2022-01-02T00:00:00Z'),
        birthDate: new Date('1990-01-01'),
        isMei: false,
        vehicles: [
            {
                id: 'veh001',
                brand: 'Toyota',
                model: 'Corolla',
                year: 2020,
                plate: 'XYZ1234',
                color: 'Red',
                createdOnUtc: new Date('2022-01-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-01-02T00:00:00Z'),
                ownerId: 'cust001',
                pictureUrl: 'http://example.com/car1.jpg'
            },
            {
                id: 'veh002',
                brand: 'Honda',
                model: 'Civic',
                year: 2019,
                plate: 'ABC5678',
                color: 'Blue',
                createdOnUtc: new Date('2022-01-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-01-02T00:00:00Z'),
                ownerId: 'cust001',
                pictureUrl: 'http://example.com/car2.jpg'
            },
            {
                id: 'veh003',
                brand: 'Ford',
                model: 'Mustang',
                year: 2021,
                plate: 'DEF9101',
                color: 'Black',
                createdOnUtc: new Date('2022-01-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-01-02T00:00:00Z'),
                ownerId: 'cust001',
                pictureUrl: 'http://example.com/car3.jpg'
            }
        ]
    },
    {
        id: 'cust002',
        firstName: 'Jane',
        lastName: 'Smith',
        fullName: 'Jane Smith',
        email: 'jane.smith@example.com',
        phone: '+0987654321',
        address: {
            street: '456 Elm St',
            number: '789',
            neighborhood: 'Uptown',
            city: 'Shelbyville',
            stateCode: 'SH',
            zipCode: '54321',
            countryCode: 'US'
        },
        type: CustomerType.Corporate,
        mechShopId: 'shop002',
        document: 'XY987654',
        createdOnUtc: new Date('2022-02-01T00:00:00Z'),
        modifiedOnUtc: new Date('2022-02-02T00:00:00Z'),
        vehicles: [
            {
                id: 'veh004',
                brand: 'BMW',
                model: 'X5',
                year: 2018,
                plate: 'GHI1234',
                color: 'White',
                createdOnUtc: new Date('2022-02-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-02-02T00:00:00Z'),
                ownerId: 'cust002',
                pictureUrl: 'http://example.com/car4.jpg'
            },
            {
                id: 'veh005',
                brand: 'Audi',
                model: 'A6',
                year: 2020,
                plate: 'JKL5678',
                color: 'Silver',
                createdOnUtc: new Date('2022-02-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-02-02T00:00:00Z'),
                ownerId: 'cust002',
                pictureUrl: 'http://example.com/car5.jpg'
            },
            {
                id: 'veh006',
                brand: 'Mercedes',
                model: 'C-Class',
                year: 2021,
                plate: 'MNO9101',
                color: 'Gray',
                createdOnUtc: new Date('2022-02-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-02-02T00:00:00Z'),
                ownerId: 'cust002',
                pictureUrl: 'http://example.com/car6.jpg'
            }
        ]
    },
    {
        id: 'cust003',
        firstName: 'Alice',
        lastName: 'Johnson',
        fullName: 'Alice Johnson',
        email: 'alice.johnson@example.com',
        phone: '+1112223333',
        address: {
            street: '789 Oak St',
            number: '123',
            neighborhood: 'Westside',
            city: 'Capital City',
            stateCode: 'CC',
            zipCode: '67890',
            countryCode: 'US'
        },
        type: CustomerType.Individual,
        mechShopId: 'shop003',
        document: 'CD234567',
        createdOnUtc: new Date('2022-03-01T00:00:00Z'),
        modifiedOnUtc: new Date('2022-03-02T00:00:00Z'),
        birthDate: new Date('1985-05-15'),
        isMei: true,
        vehicles: [
            {
                id: 'veh007',
                brand: 'Tesla',
                model: 'Model S',
                year: 2019,
                plate: 'PQR1234',
                color: 'Blue',
                createdOnUtc: new Date('2022-03-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-03-02T00:00:00Z'),
                ownerId: 'cust003',
                pictureUrl: 'http://example.com/car7.jpg'
            },
            {
                id: 'veh008',
                brand: 'Chevrolet',
                model: 'Camaro',
                year: 2020,
                plate: 'STU5678',
                color: 'Yellow',
                createdOnUtc: new Date('2022-03-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-03-02T00:00:00Z'),
                ownerId: 'cust003',
                pictureUrl: 'http://example.com/car8.jpg'
            },
            {
                id: 'veh009',
                brand: 'Nissan',
                model: 'GT-R',
                year: 2021,
                plate: 'VWX9101',
                color: 'Red',
                createdOnUtc: new Date('2022-03-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-03-02T00:00:00Z'),
                ownerId: 'cust003',
                pictureUrl: 'http://example.com/car9.jpg'
            }
        ]
    },
    {
        id: 'cust004',
        firstName: 'Bob',
        lastName: 'Brown',
        fullName: 'Bob Brown',
        email: 'bob.brown@example.com',
        phone: '+4445556666',
        address: {
            street: '123 Pine St',
            number: '321',
            neighborhood: 'Eastside',
            city: 'Metropolis',
            stateCode: 'MT',
            zipCode: '98765',
            countryCode: 'US'
        },
        type: CustomerType.Corporate,
        mechShopId: 'shop004',
        document: 'EF345678',
        createdOnUtc: new Date('2022-04-01T00:00:00Z'),
        modifiedOnUtc: new Date('2022-04-02T00:00:00Z'),
        vehicles: [
            {
                id: 'veh010',
                brand: 'Kia',
                model: 'Sorento',
                year: 2018,
                plate: 'YZA1234',
                color: 'Black',
                createdOnUtc: new Date('2022-04-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-04-02T00:00:00Z'),
                ownerId: 'cust004',
                pictureUrl: 'http://example.com/car10.jpg'
            },
            {
                id: 'veh011',
                brand: 'Hyundai',
                model: 'Elantra',
                year: 2019,
                plate: 'BCD5678',
                color: 'Silver',
                createdOnUtc: new Date('2022-04-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-04-02T00:00:00Z'),
                ownerId: 'cust004',
                pictureUrl: 'http://example.com/car11.jpg'
            },
            {
                id: 'veh012',
                brand: 'Mazda',
                model: 'CX-5',
                year: 2020,
                plate: 'EFG9101',
                color: 'White',
                createdOnUtc: new Date('2022-04-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-04-02T00:00:00Z'),
                ownerId: 'cust004',
                pictureUrl: 'http://example.com/car12.jpg'
            }
        ]
    },
    {
        id: 'cust005',
        firstName: 'Charlie',
        lastName: 'Green',
        fullName: 'Charlie Green',
        email: 'charlie.green@example.com',
        phone: '+7778889999',
        address: {
            street: '456 Maple St',
            number: '654',
            neighborhood: 'Northside',
            city: 'Gotham',
            stateCode: 'GT',
            zipCode: '12321',
            countryCode: 'US'
        },
        type: CustomerType.Individual,
        mechShopId: 'shop005',
        document: 'GH456789',
        createdOnUtc: new Date('2022-05-01T00:00:00Z'),
        modifiedOnUtc: new Date('2022-05-02T00:00:00Z'),
        birthDate: new Date('1975-12-25'),
        isMei: false,
        vehicles: [
            {
                id: 'veh013',
                brand: 'Volkswagen',
                model: 'Golf',
                year: 2017,
                plate: 'HIJ1234',
                color: 'Blue',
                createdOnUtc: new Date('2022-05-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-05-02T00:00:00Z'),
                ownerId: 'cust005',
                pictureUrl: 'http://example.com/car13.jpg'
            },
            {
                id: 'veh014',
                brand: 'Volvo',
                model: 'XC90',
                year: 2018,
                plate: 'KLM5678',
                color: 'Black',
                createdOnUtc: new Date('2022-05-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-05-02T00:00:00Z'),
                ownerId: 'cust005',
                pictureUrl: 'http://example.com/car14.jpg'
            },
            {
                id: 'veh015',
                brand: 'Subaru',
                model: 'Outback',
                year: 2019,
                plate: 'NOP9101',
                color: 'Red',
                createdOnUtc: new Date('2022-05-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-05-02T00:00:00Z'),
                ownerId: 'cust005',
                pictureUrl: 'http://example.com/car15.jpg'
            }
        ]
    },
    {
        id: 'cust006',
        firstName: 'David',
        lastName: 'White',
        fullName: 'David White',
        email: 'david.white@example.com',
        phone: '+1011121314',
        address: {
            street: '789 Birch St',
            number: '987',
            neighborhood: 'Southside',
            city: 'Star City',
            stateCode: 'SC',
            zipCode: '45678',
            countryCode: 'US'
        },
        type: CustomerType.Corporate,
        mechShopId: 'shop006',
        document: 'IJ567890',
        createdOnUtc: new Date('2022-06-01T00:00:00Z'),
        modifiedOnUtc: new Date('2022-06-02T00:00:00Z'),
        vehicles: [
            {
                id: 'veh016',
                brand: 'Lexus',
                model: 'RX',
                year: 2018,
                plate: 'QRS1234',
                color: 'Gray',
                createdOnUtc: new Date('2022-06-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-06-02T00:00:00Z'),
                ownerId: 'cust006',
                pictureUrl: 'http://example.com/car16.jpg'
            },
            {
                id: 'veh017',
                brand: 'Infiniti',
                model: 'Q50',
                year: 2019,
                plate: 'TUV5678',
                color: 'Silver',
                createdOnUtc: new Date('2022-06-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-06-02T00:00:00Z'),
                ownerId: 'cust006',
                pictureUrl: 'http://example.com/car17.jpg'
            },
            {
                id: 'veh018',
                brand: 'Acura',
                model: 'MDX',
                year: 2020,
                plate: 'WXY9101',
                color: 'White',
                createdOnUtc: new Date('2022-06-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-06-02T00:00:00Z'),
                ownerId: 'cust006',
                pictureUrl: 'http://example.com/car18.jpg'
            }
        ]
    },
    {
        id: 'cust007',
        firstName: 'Emma',
        lastName: 'Black',
        fullName: 'Emma Black',
        email: 'emma.black@example.com',
        phone: '+1516171819',
        address: {
            street: '123 Cedar St',
            number: '654',
            neighborhood: 'Westside',
            city: 'Emerald City',
            stateCode: 'EC',
            zipCode: '78901',
            countryCode: 'US'
        },
        type: CustomerType.Individual,
        mechShopId: 'shop007',
        document: 'KL678901',
        createdOnUtc: new Date('2022-07-01T00:00:00Z'),
        modifiedOnUtc: new Date('2022-07-02T00:00:00Z'),
        birthDate: new Date('1992-03-20'),
        isMei: true,
        vehicles: [
            {
                id: 'veh019',
                brand: 'Toyota',
                model: 'Highlander',
                year: 2017,
                plate: 'ZAB1234',
                color: 'Black',
                createdOnUtc: new Date('2022-07-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-07-02T00:00:00Z'),
                ownerId: 'cust007',
                pictureUrl: 'http://example.com/car19.jpg'
            },
            {
                id: 'veh020',
                brand: 'Ford',
                model: 'Explorer',
                year: 2018,
                plate: 'CDE5678',
                color: 'Blue',
                createdOnUtc: new Date('2022-07-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-07-02T00:00:00Z'),
                ownerId: 'cust007',
                pictureUrl: 'http://example.com/car20.jpg'
            },
            {
                id: 'veh021',
                brand: 'Jeep',
                model: 'Cherokee',
                year: 2019,
                plate: 'FGH9101',
                color: 'Red',
                createdOnUtc: new Date('2022-07-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-07-02T00:00:00Z'),
                ownerId: 'cust007',
                pictureUrl: 'http://example.com/car21.jpg'
            }
        ]
    },
    {
        id: 'cust008',
        firstName: 'Frank',
        lastName: 'Blue',
        fullName: 'Frank Blue',
        email: 'frank.blue@example.com',
        phone: '+2021222324',
        address: {
            street: '456 Aspen St',
            number: '321',
            neighborhood: 'Eastside',
            city: 'Central City',
            stateCode: 'CC',
            zipCode: '12322',
            countryCode: 'US'
        },
        type: CustomerType.Corporate,
        mechShopId: 'shop008',
        document: 'MN789012',
        createdOnUtc: new Date('2022-08-01T00:00:00Z'),
        modifiedOnUtc: new Date('2022-08-02T00:00:00Z'),
        vehicles: [
            {
                id: 'veh022',
                brand: 'Jaguar',
                model: 'XF',
                year: 2018,
                plate: 'IJK1234',
                color: 'Silver',
                createdOnUtc: new Date('2022-08-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-08-02T00:00:00Z'),
                ownerId: 'cust008',
                pictureUrl: 'http://example.com/car22.jpg'
            },
            {
                id: 'veh023',
                brand: 'Land Rover',
                model: 'Range Rover',
                year: 2019,
                plate: 'LMN5678',
                color: 'Black',
                createdOnUtc: new Date('2022-08-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-08-02T00:00:00Z'),
                ownerId: 'cust008',
                pictureUrl: 'http://example.com/car23.jpg'
            },
            {
                id: 'veh024',
                brand: 'Porsche',
                model: 'Cayenne',
                year: 2020,
                plate: 'OPQ9101',
                color: 'White',
                createdOnUtc: new Date('2022-08-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-08-02T00:00:00Z'),
                ownerId: 'cust008',
                pictureUrl: 'http://example.com/car24.jpg'
            }
        ]
    },
    {
        id: 'cust009',
        firstName: 'Grace',
        lastName: 'Purple',
        fullName: 'Grace Purple',
        email: 'grace.purple@example.com',
        phone: '+2526272829',
        address: {
            street: '789 Chestnut St',
            number: '654',
            neighborhood: 'Northside',
            city: 'Coast City',
            stateCode: 'CC',
            zipCode: '78902',
            countryCode: 'US'
        },
        type: CustomerType.Individual,
        mechShopId: 'shop009',
        document: 'OP890123',
        createdOnUtc: new Date('2022-09-01T00:00:00Z'),
        modifiedOnUtc: new Date('2022-09-02T00:00:00Z'),
        birthDate: new Date('1980-11-11'),
        isMei: false,
        vehicles: [
            {
                id: 'veh025',
                brand: 'Tesla',
                model: 'Model X',
                year: 2017,
                plate: 'RST1234',
                color: 'White',
                createdOnUtc: new Date('2022-09-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-09-02T00:00:00Z'),
                ownerId: 'cust009',
                pictureUrl: 'http://example.com/car25.jpg'
            },
            {
                id: 'veh026',
                brand: 'BMW',
                model: 'i8',
                year: 2018,
                plate: 'UVW5678',
                color: 'Blue',
                createdOnUtc: new Date('2022-09-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-09-02T00:00:00Z'),
                ownerId: 'cust009',
                pictureUrl: 'http://example.com/car26.jpg'
            },
            {
                id: 'veh027',
                brand: 'Audi',
                model: 'e-tron',
                year: 2019,
                plate: 'XYZ9101',
                color: 'Gray',
                createdOnUtc: new Date('2022-09-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-09-02T00:00:00Z'),
                ownerId: 'cust009',
                pictureUrl: 'http://example.com/car27.jpg'
            }
        ]
    },
    {
        id: 'cust010',
        firstName: 'Henry',
        lastName: 'Orange',
        fullName: 'Henry Orange',
        email: 'henry.orange@example.com',
        phone: '+3031323334',
        address: {
            street: '123 Fir St',
            number: '321',
            neighborhood: 'Eastside',
            city: 'Gateway City',
            stateCode: 'GC',
            zipCode: '32123',
            countryCode: 'US'
        },
        type: CustomerType.Corporate,
        mechShopId: 'shop010',
        document: 'QR901234',
        createdOnUtc: new Date('2022-10-01T00:00:00Z'),
        modifiedOnUtc: new Date('2022-10-02T00:00:00Z'),
        vehicles: [
            {
                id: 'veh028',
                brand: 'Cadillac',
                model: 'Escalade',
                year: 2018,
                plate: 'ABC1234',
                color: 'Black',
                createdOnUtc: new Date('2022-10-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-10-02T00:00:00Z'),
                ownerId: 'cust010',
                pictureUrl: 'http://example.com/car28.jpg'
            },
            {
                id: 'veh029',
                brand: 'Lincoln',
                model: 'Navigator',
                year: 2019,
                plate: 'DEF5678',
                color: 'White',
                createdOnUtc: new Date('2022-10-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-10-02T00:00:00Z'),
                ownerId: 'cust010',
                pictureUrl: 'http://example.com/car29.jpg'
            },
            {
                id: 'veh030',
                brand: 'GMC',
                model: 'Yukon',
                year: 2020,
                plate: 'GHI9101',
                color: 'Gray',
                createdOnUtc: new Date('2022-10-01T00:00:00Z'),
                modifiedOnUtc: new Date('2022-10-02T00:00:00Z'),
                ownerId: 'cust010',
                pictureUrl: 'http://example.com/car30.jpg'
            }
        ]
    }
];

export default customers;