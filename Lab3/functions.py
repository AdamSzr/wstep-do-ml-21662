import json
import requests
from functions import *
from data_struct import *
from bs4 import BeautifulSoup
import bs4


def createSheets(workbook, sheetsNames):
    worksheets = {}
    for x in sheetsNames:
        worksheets[x] = workbook.create_sheet(x)

    return worksheets


def removeSheetsOtherThen(workbook, necessarySheetsNames):
    for x in workbook.worksheets:
        if (x.title not in necessarySheetsNames):
            workbook.remove(x)


def createLinkWithId(url, id):
    return url + str(id)


isCompeted = lambda x: x['completed'] == True


def extractNecesseryDataForTodos(data):
    return TodosItem(data['id'], data['title'])


def downloadTodosData(baseUrl):
    todosData = []
    loopCounter = 1

    while len(todosData) < 3:
        obj = requests.get(createLinkWithId(baseUrl, loopCounter)).text
        obj = json.loads(obj)
        loopCounter += 1
        if isCompeted(obj):
            todosData.append(extractNecesseryDataForTodos(obj))

    return todosData


def insertTodosItemsIntoSheet(sheet, todosItems):
    acctualRow = 1
    for todosItem in todosItems:
        sheet.cell(row=acctualRow, column=1).value = todosItem.id
        sheet.cell(row=acctualRow, column=2).value = todosItem.title
        acctualRow += 1


def createSoup(url):
    return BeautifulSoup(requests.get(url).text, 'html.parser')


def findLinksWithHrefAttr(soup):
    return soup.find_all('a', {'href': True})


def insertLinksIntoSheet(sheet, linkTags):
    acctualRow = 1
    for tag in linkTags:
        sheet.cell(row=acctualRow, column=1).value = tag['href']
        acctualRow += 1


def extractPremiere(soup):
    return soup.select("div.filmInfo__info > a > span.block")[0].string


def extractFilmNote(soup):
    return soup.select(
        'div.filmRating__rate > span.filmRating__rateValue')[0].string


def extractTopPosition(soup):
    return soup.select(
        'div.filmPosterSection__buttons > a.worldRanking')[0].string


def extractDirector(soup):
    return soup.select(
        "div.filmInfo__info.cloneToCast.cloneToOtherInfo > a > span")[1].string


def insertWikipediaDataIntoSheet(sheet, data):
    sheet.cell(row=1, column=1).value = data.top
    sheet.cell(row=1, column=2).value = data.note
    sheet.cell(row=1, column=3).value = data.permiere
    sheet.cell(row=1, column=4).value = data.director
