# RPG Character Manager - Féléves feladat (NIXSG1LBNE/SZTGUI_LA_02)

**2025/26/2 - Szoftvertechnológia és grafikus felhasználói interfész tervezése**  
Repository: **NIXSG1LBNE/SZTGUI_LA_02**

---

## 👤 Személyes adatok

- **Neptun kód:** DP3HYC  
- **Név:** Nagy István Bence  
- **Labor azonosító:** 02

---

## 🎮 Projekt célja

Ez a projekt egy **egyszerű RPG karakter manager alkalmazás** WPF keretrendszerben.  
A feladat célja, hogy bemutassa a félév során tanult technikákat:

- Több ablak kezelése (MainWindow, StatEditorWindow, opcionálisan InventoryWindow)
- Adatkötés (`ObservableCollection`, `INotifyPropertyChanged`)
- Command-ok és továbbított események használata
- Rétegezett architektúra (Models, Services, ViewModels, Views)
- Git verziókezelés és GitHub integráció

A projekt demonstrálja a WPF és MVVM alapú fejlesztéshez szükséges gyakorlati ismereteket, miközben valós funkcionalitást biztosít: karakterek kezelése, statok szerkesztése, inventory menedzsment.

---

## 📁 Projekt struktúra (terv)

RPGCharacterManager/
│
├─ Models/
│ ├─ Character.cs
│ └─ InventoryItem.cs
│
├─ Services/
│ └─ CharacterService.cs
│
├─ ViewModels/
│ ├─ MainWindowViewModel.cs
│ └─ StatEditorViewModel.cs
│
├─ Views/
│ ├─ MainWindow.xaml
│ └─ StatEditorWindow.xaml
│
├─ README.md
└─ RPGCharacterManager.sln


---

## 📝 Főbb követelmények

1. **Több ablak**: MainWindow karakterlista + alapadatok, StatEditorWindow statok szerkesztése  
2. **Adatkötés**: ObservableCollection, INotifyPropertyChanged, ListBox/DataGrid binding  
3. **Eseménykezelés / Command**: egy Command több gombhoz, RoutedEvent használata  
4. **Rétegezés**: Models, Services, ViewModels, Views  
5. **Git verziókezelés**: repo inicializálás, commit, branch, push, merge kezelés  
6. **README tartalmazza**: projekt neve, Neptun kód, név, labor azonosító  

---

## 📅 Menetrend (órarend)

| Hét | Dátum       | Témakör |
|-----|------------|---------|
| 1   | 2026.02.16 | UI alapok |
| 2   | 2026.02.23 | Továbbított események |
| 3   | 2026.03.02 | Adatkötés |
| 4   | 2026.03.09 | Adatkötés (további gyakorlás) |
| 5   | 2026.03.16 | MVVM minta |
| 6   | 2026.03.23 | Gyakorlás |
| 7   | 2026.03.30 | Workshop 1 |
| 8   | 2026.04.06 | Rektori szünet |
| 9   | 2026.04.13 | Workshop 2 |
| 10  | 2026.04.20 | Workshop 2 |
| 11  | 2026.04.27 | Féléves feladat készítése, konzultáció |
| 12  | 2026.05.04 | Féléves feladat készítése, konzultáció |
| 13  | 2026.05.11 | Pót Workshop + Féléves feladatok bemutatása |
| 14  | 2026.05.18 | Féléves feladatok bemutatása (pót) |

---

## 🔧 További információk

- A projekt **incrementálisan készül**, minden lépéshez adunk kódmintát, terminál/Visual Studio utasításokat, és Git workflow-t.
- Lehetőség van a projekt továbbfejlesztésére: InventoryWindow, stat szűrés, karakterek exportálása, UI styling, input validáció.

---

> **Megjegyzés:** A projekt célja, hogy demonstrálja a félév során tanult WPF és grafikus felhasználói interfész tervezési ismereteket, rétegezett architektúrát és verziókezelés használatát.
