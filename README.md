# 💳 PayUni - Application de Gestion des Frais et Paiements Mobiles

<div align="center">

![.NET MAUI](https://img.shields.io/badge/.NET%20MAUI-9.0+-512BD4?style=for-the-badge&logo=.net)
![C#](https://img.shields.io/badge/C%23-12+-239120?style=for-the-badge&logo=c-sharp)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

**Une solution moderne et intuitive pour gérer vos frais universitaires et paiements mobiles**

[Fonctionnalités](#-fonctionnalités) • [Installation](#-installation) • [Architecture](#️-architecture) • [Design System](#-design-system) • [Contribution](#-contribution)

</div>

---

## 🎯 À Propos

**PayUni** est une application mobile cross-platform développée avec **.NET MAUI** qui révolutionne la gestion des frais de paiement, des transactions sécurisées et de l'historique financier. Conçue avec une approche mobile-first, elle offre une expérience utilisateur fluide et sécurisée sur iOS, Android, macOS et Windows.

### ✨ Philosophie de Conception

| Principe | Description |
|----------|-------------|
| 🎯 **Simplicité** | Interface épurée où chaque élément a sa raison d'être |
| ⚡ **Efficacité** | Navigation intuitive et actions rapides |
| ♿ **Accessibilité** | Contraste élevé, thèmes adaptatifs, navigation optimisée |
| 🔒 **Sécurité** | Authentification robuste et transactions chiffrées |
| 📱 **Mobile-First** | Optimisée pour les écrans tactiles de toutes tailles |

---

## 🚀 Fonctionnalités

### 🔐 Authentification & Profil
- ✅ Connexion et inscription sécurisées avec validation avancée
- ✅ Gestion complète du profil utilisateur
- ✅ Authentification à deux facteurs (2FA)
- ✅ Paramètres personnalisables (thème, notifications, langue)
- ✅ Gestion des mots de passe et sécurité du compte

### 📊 Tableau de Bord Intelligent
- 💰 Affichage dynamique du solde avec animations
- 📈 Statistiques financières en temps réel
- ⚡ Raccourcis vers les actions fréquentes
- 📝 Aperçu des transactions récentes
- 🔔 Centre de notifications et alertes

### 💵 Catalogue des Frais
- 📋 Liste complète et interactive des frais applicables
- 🔍 Système de filtrage multi-critères (catégorie, montant, statut)
- 🔎 Recherche instantanée et intelligente
- 📄 Détails exhaustifs avec conditions et échéances
- 📅 Historique des paiements par frais

### 💳 Système de Paiement Sécurisé
- 🎯 Interface de paiement intuitive et guidée
- 💰 Sélection flexible du montant et de la méthode
- ✔️ Écran de confirmation transparent avec récapitulatif
- 🔐 Traitement sécurisé avec chiffrement end-to-end
- 🧾 Génération instantanée de reçus officiels
- 📊 Suivi des tentatives de paiement

### 📜 Historique & Archives
- 📚 Consultation complète de toutes les transactions
- 🔽 Filtres avancés (date, statut, type, montant, référence)
- 🧾 Accès permanent aux reçus et justificatifs
- 📤 Export de données (PDF, CSV, Excel)
- 🔍 Recherche par référence ou mots-clés
- 📊 Visualisation des statuts transactionnels

### 🧭 Navigation Fluide
- 📱 Barre de navigation inférieure persistante
- ⚡ Accès rapide aux 4 sections principales
- 🔄 Transitions animées et naturelles
- 💾 Gestion intelligente de l'état de l'application

---

## 📦 Installation

### Prérequis

```bash
# .NET SDK 9.0 ou supérieur
dotnet --version  # Devrait afficher 9.0.x ou plus

# Workloads .NET MAUI
dotnet workload install maui

# Pour iOS (macOS uniquement)
xcode-select --install

# Pour Android
# Android SDK 33+ via Visual Studio ou Android Studio
```

### Configuration du Projet

```bash
# 1. Cloner le repository
git clone https://github.com/votre-username/payuni.git
cd payuni

# 2. Restaurer les dépendances
dotnet restore

# 3. Construire le projet
dotnet build

# 4. Lancer l'application (Android)
dotnet build -t:Run -f net9.0-android

# 5. Lancer l'application (iOS - macOS uniquement)
dotnet build -t:Run -f net9.0-ios

# 6. Lancer l'application (Windows)
dotnet build -t:Run -f net9.0-windows10.0.19041.0
```

### Configuration de l'Environnement

Créez un fichier `appsettings.json` à la racine du projet :

```json
{
  "ApiBaseUrl": "https://api.payuni.com",
  "DatabaseName": "payuni.db3",
  "EnableLogging": true,
  "CacheExpiration": 300
}
```

---

## 🏗️ Architecture Technique

### 📚 Stack Technologique

| Composant | Technologie | Version |
|-----------|-------------|---------|
| **Framework** | .NET MAUI | 9.0+ |
| **Pattern** | MVVM Toolkit | Community Toolkit |
| **Langage** | C# | 12+ |
| **UI Markup** | XAML | - |
| **Sécurité** | SecureStorage, HTTPS/TLS | - |
| **Base de Données** | SQLite + EF Core | 8.0+ |
| **Injection de Dépendances** | Microsoft.Extensions.DependencyInjection | 9.0+ |
| **Navigation** | Shell Navigation | Built-in |

### 📁 Structure du Projet

```
PayUni/
│
├── 📂 Models/                        # Modèles de données métier
│   ├── User.cs                       # Entité utilisateur
│   ├── Transaction.cs                # Entité transaction
│   ├── Fee.cs                        # Entité frais
│   ├── Payment.cs                    # Entité paiement
│   ├── Receipt.cs                    # Entité reçu
│   └── 📂 Enums/                     # Types énumérés
│       ├── TransactionStatus.cs      # Statuts de transaction
│       ├── PaymentMethod.cs          # Méthodes de paiement
│       ├── FeeCategory.cs            # Catégories de frais
│       └── UserRole.cs               # Rôles utilisateur
│
├── 📂 ViewModels/                    # Logique de présentation (MVVM)
│   ├── Base/
│   │   └── BaseViewModel.cs          # ViewModel de base
│   ├── LoginViewModel.cs             # Authentification
│   ├── RegisterViewModel.cs          # Inscription
│   ├── DashboardViewModel.cs         # Tableau de bord
│   ├── FeesViewModel.cs              # Liste des frais
│   ├── FeeDetailViewModel.cs         # Détail d'un frais
│   ├── PaymentViewModel.cs           # Processus de paiement
│   ├── ConfirmationViewModel.cs      # Confirmation de paiement
│   ├── HistoryViewModel.cs           # Historique des transactions
│   ├── ReceiptViewModel.cs           # Affichage du reçu
│   └── ProfileViewModel.cs           # Gestion du profil
│
├── 📂 Views/                         # Interface utilisateur (XAML)
│   ├── Auth/
│   │   ├── LoginPage.xaml            # Page de connexion
│   │   └── RegisterPage.xaml         # Page d'inscription
│   ├── Main/
│   │   ├── DashboardPage.xaml        # Tableau de bord principal
│   │   ├── FeesPage.xaml             # Liste des frais
│   │   ├── FeeDetailPage.xaml        # Détail d'un frais
│   │   ├── PaymentPage.xaml          # Interface de paiement
│   │   ├── ConfirmationPage.xaml     # Confirmation de transaction
│   │   ├── HistoryPage.xaml          # Historique complet
│   │   ├── ReceiptPage.xaml          # Reçu de transaction
│   │   └── ProfilePage.xaml          # Profil utilisateur
│   └── Components/
│       ├── FeeCard.xaml              # Carte de frais réutilisable
│       ├── TransactionCard.xaml      # Carte de transaction
│       └── StatCard.xaml             # Carte de statistique
│
├── 📂 Services/                      # Couche métier et logique
│   ├── 📂 Interfaces/
│   │   ├── IAuthenticationService.cs # Authentification
│   │   ├── IUserService.cs           # Gestion utilisateurs
│   │   ├── ITransactionService.cs    # Gestion transactions
│   │   ├── IPaymentService.cs        # Traitement paiements
│   │   ├── IFeeService.cs            # Gestion des frais
│   │   ├── INavigationService.cs     # Navigation
│   │   └── IDialogService.cs         # Dialogues et alertes
│   └── 📂 Implementations/
│       ├── AuthenticationService.cs
│       ├── UserService.cs
│       ├── TransactionService.cs
│       ├── PaymentService.cs
│       ├── FeeService.cs
│       ├── NavigationService.cs
│       └── DialogService.cs
│
├── 📂 Data/                          # Accès aux données
│   ├── AppDbContext.cs               # Contexte Entity Framework
│   ├── 📂 Repositories/
│   │   ├── IRepository.cs            # Interface générique
│   │   ├── Repository.cs             # Implémentation générique
│   │   └── ...                       # Repositories spécifiques
│   └── 📂 Migrations/                # Migrations EF Core
│
├── 📂 Resources/                     # Ressources de l'application
│   ├── 📂 Styles/
│   │   ├── Colors.xaml               # Palette de couleurs
│   │   ├── Styles.xaml               # Styles globaux
│   │   └── Themes.xaml               # Thèmes (clair/sombre)
│   ├── 📂 Images/                    # Images et illustrations
│   ├── 📂 Fonts/                     # Polices personnalisées
│   └── 📂 Raw/                       # Ressources brutes
│
├── 📂 Converters/                    # Convertisseurs XAML
│   ├── StatusToColorConverter.cs     # Couleur selon statut
│   ├── AmountFormatterConverter.cs   # Formatage des montants
│   ├── DateFormatterConverter.cs     # Formatage des dates
│   ├── BoolToVisibilityConverter.cs  # Visibilité conditionnelle
│   └── InverseBoolConverter.cs       # Inversion booléenne
│
├── 📂 Behaviors/                     # Comportements XAML
│   ├── NumericValidationBehavior.cs  # Validation numérique
│   ├── EmailValidationBehavior.cs    # Validation email
│   └── MaxLengthBehavior.cs          # Limitation de longueur
│
├── 📂 Helpers/                       # Classes utilitaires
│   ├── ValidationHelper.cs           # Validation de formulaires
│   ├── SecureStorageHelper.cs        # Stockage sécurisé
│   ├── DateTimeHelper.cs             # Gestion des dates
│   ├── CurrencyHelper.cs             # Formatage monétaire
│   └── NetworkHelper.cs              # Gestion réseau
│
├── 📂 Constants/                     # Constantes de l'application
│   ├── ApiEndpoints.cs               # Points d'entrée API
│   ├── AppConstants.cs               # Constantes générales
│   └── StorageKeys.cs                # Clés de stockage
│
├── App.xaml & App.xaml.cs            # Point d'entrée de l'application
├── AppShell.xaml & AppShell.xaml.cs  # Configuration Shell et routing
├── MauiProgram.cs                    # Configuration services & DI
└── PayUni.csproj                     # Configuration du projet
```

### 🔄 Flux de Données (MVVM)

```
┌─────────────┐         ┌──────────────┐         ┌─────────────┐
│    View     │◄────────┤  ViewModel   │◄────────┤   Service   │
│   (XAML)    │ Binding │   (Logic)    │ Calls   │  (Business) │
└─────────────┘         └──────────────┘         └─────────────┘
      │                        │                         │
      │ Commands               │ ObservableProperty      │
      └────────────────────────┘                         │
                                                          ▼
                                                  ┌─────────────┐
                                                  │ Repository  │
                                                  │   (Data)    │
                                                  └─────────────┘
                                                          │
                                                          ▼
                                                  ┌─────────────┐
                                                  │   SQLite    │
                                                  │  Database   │
                                                  └─────────────┘
```

---

## 🎨 Design System

### 🎨 Palette de Couleurs

#### 🌞 Light Mode

| Couleur | Utilisation | Hex | Preview |
|---------|-------------|-----|---------|
| **Primary** | Boutons principaux, Headers | `#2563EB` | ![#2563EB](https://via.placeholder.com/20/2563EB/2563EB.png) |
| **Primary Light** | Fond actif, Cartes | `#DBEAFE` | ![#DBEAFE](https://via.placeholder.com/20/DBEAFE/DBEAFE.png) |
| **Secondary** | Succès, Confirmations | `#10B981` | ![#10B981](https://via.placeholder.com/20/10B981/10B981.png) |
| **Danger** | Erreurs, Suppressions | `#EF4444` | ![#EF4444](https://via.placeholder.com/20/EF4444/EF4444.png) |
| **Warning** | Avertissements | `#F59E0B` | ![#F59E0B](https://via.placeholder.com/20/F59E0B/F59E0B.png) |
| **Background** | Fond principal | `#FFFFFF` | ![#FFFFFF](https://via.placeholder.com/20/FFFFFF/FFFFFF.png) |
| **Surface** | Cartes, Conteneurs | `#F9FAFB` | ![#F9FAFB](https://via.placeholder.com/20/F9FAFB/F9FAFB.png) |
| **Text Primary** | Texte principal | `#1F2937` | ![#1F2937](https://via.placeholder.com/20/1F2937/1F2937.png) |
| **Text Secondary** | Texte secondaire | `#6B7280` | ![#6B7280](https://via.placeholder.com/20/6B7280/6B7280.png) |
| **Border** | Bordures, Séparateurs | `#E5E7EB` | ![#E5E7EB](https://via.placeholder.com/20/E5E7EB/E5E7EB.png) |

#### 🌙 Dark Mode

| Couleur | Utilisation | Hex | Preview |
|---------|-------------|-----|---------|
| **Primary** | Boutons, Accents | `#3B82F6` | ![#3B82F6](https://via.placeholder.com/20/3B82F6/3B82F6.png) |
| **Background** | Fond principal | `#111827` | ![#111827](https://via.placeholder.com/20/111827/111827.png) |
| **Surface** | Cartes, Conteneurs | `#1F2937` | ![#1F2937](https://via.placeholder.com/20/1F2937/1F2937.png) |
| **Text Primary** | Texte principal | `#F3F4F6` | ![#F3F4F6](https://via.placeholder.com/20/F3F4F6/F3F4F6.png) |
| **Text Secondary** | Texte secondaire | `#9CA3AF` | ![#9CA3AF](https://via.placeholder.com/20/9CA3AF/9CA3AF.png) |
| **Border** | Bordures | `#374151` | ![#374151](https://via.placeholder.com/20/374151/374151.png) |

### ✍️ Typographie

```css
/* Heading 1 - Titres Principaux */
Font-Family: Segoe UI, -apple-system, BlinkMacSystemFont
Font-Size: 32px (2rem)
Font-Weight: Bold (700)
Line-Height: 1.2
Letter-Spacing: -0.02em

/* Heading 2 - Sous-titres */
Font-Size: 24px (1.5rem)
Font-Weight: SemiBold (600)
Line-Height: 1.3

/* Heading 3 - Titres de section */
Font-Size: 20px (1.25rem)
Font-Weight: SemiBold (600)
Line-Height: 1.4

/* Body - Corps de texte */
Font-Size: 16px (1rem)
Font-Weight: Regular (400)
Line-Height: 1.5

/* Body Small - Textes secondaires */
Font-Size: 14px (0.875rem)
Font-Weight: Regular (400)
Line-Height: 1.4

/* Label - Étiquettes de champs */
Font-Size: 12px (0.75rem)
Font-Weight: SemiBold (600)
Line-Height: 1.3
Text-Transform: Uppercase
Letter-Spacing: 0.05em
```

### 📐 Espacement & Layout

```
Unité de Base: 4px
─────────────────────
Scale:
├─ xs:  4px  (0.25rem)
├─ sm:  8px  (0.5rem)
├─ md:  12px (0.75rem)
├─ lg:  16px (1rem)
├─ xl:  24px (1.5rem)
├─ 2xl: 32px (2rem)
├─ 3xl: 48px (3rem)
└─ 4xl: 64px (4rem)

Border Radius:
├─ Small:  4px  (Inputs, Chips)
├─ Medium: 8px  (Boutons, Cards)
├─ Large:  12px (Modales)
└─ XLarge: 16px (Images, Conteneurs)

Shadows:
├─ Small:  0 1px 2px rgba(0,0,0,0.05)
├─ Medium: 0 4px 6px rgba(0,0,0,0.07)
├─ Large:  0 10px 15px rgba(0,0,0,0.1)
└─ XLarge: 0 20px 25px rgba(0,0,0,0.15)
```

### 🧩 Composants Réutilisables

#### Boutons

```xaml
<!-- Primary Button -->
<Button Text="Payer Maintenant"
        Style="{StaticResource PrimaryButton}"
        Command="{Binding PayCommand}"
        Padding="16,12"
        CornerRadius="8" />

<!-- Secondary Button -->
<Button Text="Annuler"
        Style="{StaticResource SecondaryButton}"
        Command="{Binding CancelCommand}"
        Padding="16,12" />

<!-- Danger Button -->
<Button Text="Supprimer"
        Style="{StaticResource DangerButton}"
        Command="{Binding DeleteCommand}"
        Padding="16,12" />

<!-- Outlined Button -->
<Button Text="Voir Plus"
        Style="{StaticResource OutlinedButton}"
        Command="{Binding ViewMoreCommand}" />
```

#### Cartes

```xaml
<!-- Fee Card -->
<Frame Style="{StaticResource CardFrame}"
       Padding="16"
       Margin="8">
    <Grid RowDefinitions="Auto,Auto,Auto"
          ColumnDefinitions="*,Auto">
        
        <Label Text="{Binding Title}"
               Style="{StaticResource CardTitle}"
               Grid.Row="0" Grid.Column="0" />
               
        <Label Text="{Binding Amount, StringFormat='{0:C}'}"
               Style="{StaticResource AmountText}"
               Grid.Row="0" Grid.Column="1" />
               
        <Label Text="{Binding Description}"
               Style="{StaticResource CardDescription}"
               Grid.Row="1" Grid.ColumnSpan="2" />
               
        <Button Text="Payer"
                Style="{StaticResource PrimaryButton}"
                Grid.Row="2" Grid.ColumnSpan="2"
                Command="{Binding PayCommand}" />
    </Grid>
</Frame>
```

#### Champs de Saisie

```xaml
<!-- Standard Entry -->
<Entry Placeholder="Entrez le montant"
       Keyboard="Numeric"
       Style="{StaticResource StandardEntry}"
       Text="{Binding Amount, Mode=TwoWay}" />

<!-- Password Entry -->
<Entry Placeholder="Mot de passe"
       IsPassword="True"
       Style="{StaticResource StandardEntry}"
       Text="{Binding Password, Mode=TwoWay}" />

<!-- Entry avec Validation -->
<Entry Placeholder="Email"
       Keyboard="Email"
       Style="{StaticResource StandardEntry}"
       Text="{Binding Email, Mode=TwoWay}">
    <Entry.Behaviors>
        <behaviors:EmailValidationBehavior />
    </Entry.Behaviors>
</Entry>
```

---

## 🔒 Sécurité

### Bonnes Pratiques Implémentées

- ✅ **Chiffrement des données sensibles** avec SecureStorage
- ✅ **Communications HTTPS/TLS** pour toutes les requêtes API
- ✅ **Authentification JWT** avec refresh tokens
- ✅ **Validation côté client et serveur** pour tous les inputs
- ✅ **Protection contre les injections SQL** via Entity Framework
- ✅ **Gestion sécurisée des mots de passe** (hashing avec bcrypt)
- ✅ **Authentification à deux facteurs (2FA)** optionnelle
- ✅ **Timeouts de session** configurables
- ✅ **Logs d'audit** pour les opérations sensibles




## 🤝 Contribution

Les contributions sont les bienvenues ! Voici comment participer :

1. **Fork** le projet
2. Créez une branche pour votre fonctionnalité (`git checkout -b feature/AmazingFeature`)
3. Committez vos changements (`git commit -m 'Add some AmazingFeature'`)
4. Pushez vers la branche (`git push origin feature/AmazingFeature`)
5. Ouvrez une **Pull Request**

### Standards de Code

- Respecter les conventions C# et .NET
- Suivre le pattern MVVM strictement
- Ajouter des tests unitaires pour les nouvelles fonctionnalités
- Documenter les méthodes publiques
- Utiliser des noms de variables descriptifs en français

---

## 📄 License

Ce projet est sous licence MIT. Voir le fichier `LICENSE` pour plus de détails.

---
