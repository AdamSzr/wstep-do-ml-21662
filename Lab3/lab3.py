from bs4 import BeautifulSoup
import bs4
from openpyxl import Workbook
from openpyxl.utils import get_column_letter
import json
import requests
from functions import *

# utwórz za pomocą openpyxl trzy arkusze o nazwach "Todos", "Linki" i "Filmweb",
# pod adresem znajdziesz 200 zasobów typu ToDo,

# pojedynczy zasób jest dostępny np. pod adresem https://jsonplaceholder.typicode.com/todos/x, gdzie x to liczba z zakresu <1, 200>,

# wygeneruj w pętli kolejne pseudolosowe adresy pojedynczych zasobów, aż do znalezienia trzech takich dla których completed: true.
#  Zapisz w arkuszu "Todos" wartości znalezionych 'id' oraz 'title'.

# dla wybranej strony internetowej napisz kod, który połączy się ze stroną, znajdzie wszystkie linki (co najmniej 10)
# na stronie (znacznik ‘a’ posiadający atrybut ‘href’), a następnie zapisze je do arkusza ‘Linki’,

# dla ustalonego linku do filmu na Filmwebie, np. tego, napisz kod, który zwróci:
# nazwisko reżysera,
# datę premiery,
# boxoffice,
# ocenę filmu.
# zapisz uzyskane wyniki do arkusza ‘Filmweb’.

# zapisz plik z wynikami trzech zadań w formie ‘nazwisko-grupa.xlsx

sheetsNames = ["Todos", "Linki", "Filmweb"]
fileName = "szreiber-185ic-a2.xlsx"
todosUrl = "https://jsonplaceholder.typicode.com/todos/"
wikipediaUrl = "https://pl.wikipedia.org/wiki/Common_Intermediate_Language"
gladiatorUrl = "https://www.filmweb.pl/film/Gladiator-2000-936"

wb = Workbook()

sheets = createSheets(wb, sheetsNames)
print(sheets)

removeSheetsOtherThen(wb, sheetsNames)
todosItems = downloadTodosData(todosUrl)

insertTodosItemsIntoSheet(sheets['Todos'], todosItems)

soup = createSoup(wikipediaUrl)
links = findLinksWithHrefAttr(soup)
insertLinksIntoSheet(sheets['Linki'], links)

soup = createSoup(gladiatorUrl)
wikipediaData = WikipediaDataStruct(extractTopPosition(soup), extractFilmNote(soup), extractPremiere(soup), extractDirector(soup));
insertWikipediaDataIntoSheet(sheets['Filmweb'],wikipediaData)

wb.save(fileName)
