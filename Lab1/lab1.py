import numpy as np

#%%
# utwórz tablicę zawierającą 10 zer,
zeros = np.zeros(10)
print("tablica zawierająca 10 zer -> \r\n", zeros)

#%%
# utwórz tablicę zawierającą 10 piątek,
fiveteen = np.full(5, 10)
print("tablica zawierająca 10 piatek -> \r\n",fiveteen)

#%%
# utwórz tablicę zawierającą liczby od 10 do 50,
fromTenToFifty = np.arange(10, 50)
print("tablica zawierająca od 10 do 50 z przeskokiem o 1 -> \r\n",fromTenToFifty)

#%%
# utwórz macierz (tablica wielowymiarowa) o wymiarach 3x3 zawierającą liczby od 0 do 8,
arrayOneDim = np.arange(0, 9)
multiDim = arrayOneDim.reshape(3, 3)
print("macierz o wymiarach 3x3 zawierającą liczby od 0 do 8 -> \r\n",multiDim)

# %%
# utwórz macierz jednostkową o wymiarach 3x3,
print("macierz jednostkową o wymiarach 3x3 -> \r\n",np.eye(3))

# %%
# utwórz macierz o wymiarach 5x5 zawierającą liczby z dystrybucji normalnej (Gaussa),
print("macierz o wymiarach 5x5 zawierającą liczby z dystrybucji normalnej -> \r\n",np.random.normal(1, 1, 25).reshape(5, 5))

# %%
# utwórz macierz o wymiarach 10x10 zawierającą liczby od 0,01 do 1 z krokiem 0,01,
print("macierz o wymiarach 10x10 zawierającą liczby od 0,01 do 1 z krokiem 0,01 -> \r\n" ,np.linspace(0.01, 1, 100))

# %%
# utwórz tablicę zawierającą 20 liniowo rozłożonych liczb między 0 a 1 (włącznie z 0 i 1),
print("tablica zawierająca 20 liniowo rozłożonych liczb między 0 a 1 (włącznie z 0 i 1) -> \r\n" ,np.linspace(0, 1, 20))

# %%
# utwórz tablicę zawierającą losowe liczby z przedziału (1, 25), następnie zamień ją na macierz o wymiarach 5 x 5 z tymi samymi liczbam
complexArray = np.add(np.random.randint(25, size=25), 1).reshape(5, 5)
print("tablicę zawierającą losowe liczby z przedziału (1, 25), następnie zamień ją na macierz o wymiarach 5 x 5 z tymi samymi liczbam -> \r\n",complexArray)

# oblicz sumę wszystkich liczb w ww. macierzy,
print("suma wszystkich liczb w ww. macierzy -> \r\n",complexArray.sum())

# oblicz średnią wszystkich liczb w ww. macierzy,
print("średnia wszystkich liczb w ww. macierzy -> \r\n",complexArray.mean())

# oblicz standardową dewiację dla liczb w ww. macierzy,
print("standardową dewiację dlaliczb w ww. macierzy -> \r\n",np.std(complexArray))

# oblicz sumę każdej kolumny ww. macierzy i zapisz ją do tablicy.
sumOfComplexArrayCollumns = np.sum(complexArray, axis=0)
print("sumę każdej kolumny ww. macierzy i zapisz ją do tablicy -> \r\n",sumOfComplexArrayCollumns)

# %%
# utwórz macierz o wymiarach 5x5 zawierającą losowe liczby z przedziału (0, 100) oraz
complexArray = np.random.randint(100, size=25).reshape(5, 5)
print("macierz o wymiarach 5x5 zawierającą losowe liczby z przedziału (0, 100) -> \r\n",complexArray)

# oblicz medianę tych liczb,
print("mediana liczb -> \r\n",np.median(complexArray))

#znajdź najmniejszą liczbę tej macierzy,
print("najmniejsza liczba w macierzy -> \r\n",complexArray.min())

#znajdź największą liczbę tej macierzy.
print("największą liczba w macierzy -> \r\n",complexArray.max())

#%%
# utwórz macierz o wymiarach różnych od siebie i większych od 1, zawierającą losowe liczby z przedziału (0, 100) i dokonaj jej transpozycji,
complexArray = np.random.randint(0, 100, size=(5, 3))
print("macierz o wymiarach różnych od siebie i większych od 1, zawierająca losowe liczby z przedziału (0, 100) i po transpozycji -> \r\n", complexArray.transpose())

#%%
# utwórz dwie macierze o odpowiednich wymiarach, większych od 2x2 i dodaj je do siebie,
component1 = np.random.randint(0, 100, size=(5, 5))
component2 = np.random.randint(0, 100, size=(5, 5))
print("Suma dwóch macierzy -> \r\n", component1 + component2)

# utwórz dwie macierze o odpowiednich wymiarach różnych od siebie i większych od 2,
#  a następnie pomnóż je przez siebie za pomocą dwóch różnych funkcji (np. ‘matmul’ i ‘multiply’, proszę poczytać o różnicach w obliczaniu wyników mnożenia).
# Możemy mnożyć dwie macierze tylko wówczas gdy ilość kolumn pierwszej macierzy jest taka sama jak ilość wierszy drugiej macierzy

print("Mnożenie za pomocą matmul -> \r\n",np.matmul(component1, component2))  # jest to typowe mnożenie matryc
print("Mnożenie za pomocą multiply -> \r\n",np.multiply(component1,component2))  # mnozenie component1[0,0]*component2[0,0] itd.
