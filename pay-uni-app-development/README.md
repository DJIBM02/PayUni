# PayUni - Application de Gestion des Frais et Paiements Mobiles

## 📱 À Propos

**PayUni** est une application mobile cross-platform construite avec **.NET MAUI** conçue pour simplifier la gestion des frais de paiement, les transactions sécurisées et l'historique financier. L'application offre une expérience utilisateur intuitive et sobrement fonctionnelle, mettant l'accent sur la transparence, la sécurité et l'accessibilité.

### Philosophie de Conception

- **Simplicité** : Chaque élément a sa raison d'être
- **Efficacité** : Interface sobre et fonctionnelle
- **Accessibilité** : Contraste élevé, thèmes clair/sombre, navigation intuitive
- **Sécurité** : Authentification sécurisée, transactions chiffrées
- **Mobile-First** : Optimisée pour les écrans tactiles et petits appareils

---

## 🎯 Fonctionnalités Principales

### 1. Authentification & Profil
- Connexion et inscription sécurisées
- Gestion du profil utilisateur
- Paramètres de sécurité (2FA, mot de passe)
- Préférences (thème clair/sombre, notifications)

### 2. Tableau de Bord
- Affichage proéminent du solde personnel
- Vue d'ensemble des statistiques financières
- Raccourcis vers les actions fréquentes
- Transactions récentes en un coup d'œil
- Alertes et notifications importantes

### 3. Catalogue des Frais
- Listing complet et interactif des frais applicables
- Système de filtrage avancé (par catégorie, montant)
- Fonction de recherche intégrée
- Détail complet de chaque frais avec conditions
- Affichage du dernier paiement du frais

### 4. Système de Paiement Sécurisé
- Interface de paiement intuitive
- Sélection du montant et de la méthode
- Écran de confirmation transparent
- Validation et traitement sécurisé
- Génération immédiate de reçu
- Historique des tentatives de paiement

### 5. Historique & Archives
- Listing complet de toutes les transactions
- Filtres par date, statut, type, montant
- Accès aux reçus officiels
- Export de données
- Recherche par référence de transaction
- Statuts transactionnels détaillés

### 6. Navigation Intuitive
- Barre de navigation inférieure persistante
- Accès rapide à 4 sections clés : Tableau de Bord, Frais, Paiement, Profil
- Navigation fluide entre les écrans
- Gestion de l'état intuitif

---

## 🛠️ Architecture Technique

### Stack Technologique

| Composant | Technologie |
|-----------|-------------|
| **Framework** | .NET MAUI 9.0+ |
| **Pattern MVVM** | MVVM Toolkit (Community Toolkit) |
| **Langage** | C# 12+ |
| **UI Markup** | XAML |
| **Sécurité** | SecureStorage, HTTPS/TLS |
| **Stockage Local** | SQLite avec Entity Framework Core |
| **Gestion d'État** | RelayCommand, ObservableObject |

### Structure du Projet

\`\`\`
PayUni/
├── Models/                          # Modèles de données
│   ├── User.cs                      # Utilisateur
│   ├── Transaction.cs               # Transaction
│   ├── Fee.cs                       # Frais
│   ├── Payment.cs                   # Paiement
│   └── Enums/                       # Types énumérés
│       ├── TransactionStatus.cs
│       ├── PaymentMethod.cs
│       └── FeeCategory.cs
│
├── ViewModels/                      # Logique de présentation
│   ├── LoginViewModel.cs            # Authentification
│   ├── DashboardViewModel.cs        # Tableau de bord
│   ├── FeesViewModel.cs             # Gestion des frais
│   ├── PaymentViewModel.cs          # Processus de paiement
│   ├── HistoryViewModel.cs          # Historique
│   └── ProfileViewModel.cs          # Profil utilisateur
│
├── Views/                           # Interface utilisateur XAML
│   ├── LoginPage.xaml               # Page de connexion
│   ├── DashboardPage.xaml           # Tableau de bord
│   ├── FeesPage.xaml                # Liste des frais
│   ├── FeeDetailPage.xaml           # Détail d'un frais
│   ├── PaymentPage.xaml             # Paiement
│   ├── ConfirmationPage.xaml        # Confirmation
│   ├── HistoryPage.xaml             # Historique
│   ├── ProfilePage.xaml             # Profil
│   └── ReceiptPage.xaml             # Reçu
│
├── Services/                        # Services métier
│   ├── Interfaces/
│   │   ├── IAuthenticationService.cs
│   │   ├── IUserService.cs
│   │   ├── ITransactionService.cs
│   │   ├── IPaymentService.cs
│   │   └── IFeeService.cs
│   └── Implementations/
│       ├── AuthenticationService.cs
│       ├── UserService.cs
│       ├── TransactionService.cs
│       ├── PaymentService.cs
│       └── FeeService.cs
│
├── Resources/                       # Ressources (couleurs, styles)
│   ├── Colors.xaml                  # Palette de couleurs
│   ├── Styles.xaml                  # Styles réutilisables
│   └── Images/                      # Images et icônes
│
├── Converters/                      # Convertisseurs XAML
│   ├── StatusToColorConverter.cs     # Couleur selon statut
│   ├── AmountFormatter.cs           # Formatage des montants
│   └── DateFormatter.cs             # Formatage des dates
│
├── Utilities/                       # Utilitaires
│   ├── ValidationHelper.cs          # Validation de formulaires
│   ├── SecureStorageHelper.cs       # Stockage sécurisé
│   └── DateTimeHelper.cs            # Gestion des dates
│
├── App.xaml & App.xaml.cs           # Configuration de l'application
├── AppShell.xaml & AppShell.xaml.cs # Routing et navigation
├── MauiProgram.cs                   # Configuration services & DI
└── PayUni.csproj                    # Configuration du projet
\`\`\`

---

## 🎨 Système de Design

### Palette de Couleurs

#### Light Mode (Par défaut)

| Couleur | Utilisation | Valeur Hex |
|---------|-------------|-----------|
| **Primaire** | Boutons principaux, Headers, Accents | `#2563EB` (Bleu) |
| **Primaire Clair** | Fond des cartes, Zones actives | `#DBEAFE` |
| **Secondaire** | Actions confirmées, Succès | `#10B981` (Vert) |
| **Danger** | Erreurs, Alertes critiques | `#EF4444` (Rouge) |
| **Avertissement** | Avertissements, États transitoires | `#F59E0B` (Ambre) |
| **Fond Principal** | Arrière-plan général | `#FFFFFF` |
| **Fond Secondaire** | Cartes, Conteneurs | `#F9FAFB` |
| **Texte Principal** | Titres, Corps de texte | `#1F2937` (Gris 900) |
| **Texte Secondaire** | Labels, Sous-texte | `#6B7280` (Gris 500) |
| **Bordures** | Séparations, Contours | `#E5E7EB` (Gris 200) |

#### Dark Mode

| Couleur | Utilisation | Valeur Hex |
|---------|-------------|-----------|
| **Primaire** | Boutons, Accents | `#3B82F6` (Bleu clair) |
| **Fond Principal** | Arrière-plan général | `#111827` (Gris 900) |
| **Fond Secondaire** | Cartes, Conteneurs | `#1F2937` (Gris 800) |
| **Texte Principal** | Titres, Corps | `#F3F4F6` (Gris 100) |
| **Texte Secondaire** | Labels, Sous-texte | `#9CA3AF` (Gris 400) |
| **Bordures** | Séparations | `#374151` (Gris 700) |

### Typographie

\`\`\`
HEADING 1 (Titres Principaux)
- Font: Segoe UI / -apple-system
- Taille: 32px
- Poids: Bold (700)
- Line Height: 1.2

HEADING 2 (Sous-titres)
- Font: Segoe UI
- Taille: 24px
- Poids: SemiBold (600)
- Line Height: 1.3

BODY (Corps de texte)
- Font: Segoe UI / Roboto
- Taille: 16px
- Poids: Regular (400)
- Line Height: 1.5

BODY SMALL (Textes secondaires)
- Font: Segoe UI
- Taille: 14px
- Poids: Regular (400)
- Line Height: 1.4

LABEL (Étiquettes)
- Font: Segoe UI
- Taille: 12px
- Poids: SemiBold (600)
- Line Height: 1.3
\`\`\`

### Espacement & Layout

- **Unité de Base** : 4px (multiples de 4)
- **Spacing Scale** : 4px, 8px, 12px, 16px, 24px, 32px, 48px
- **Border Radius** : 8px (standard), 12px (cartes), 4px (inputs)
- **Shadows** : Subtiles, élévation progressive

### Composants Réutilisables

#### Bouttons
```xaml
<!-- Primary Button -->
<Button Text="Payer" 
        BackgroundColor="#2563EB" 
        TextColor="White" 
        Padding="16,12" 
        CornerRadius="8" />

<!-- Secondary Button -->
<Button Text="Annuler" 
        BackgroundColor="#F9FAFB" 
        TextColor="#1F2937" 
        Padding="16,12" 
        BorderColor="#E5E7EB" 
        BorderWidth="1" />

<!-- Danger Button -->
<Button Text="Supprimer" 
        BackgroundColor="#EF4444" 
        TextColor="White" 
        Padding="16,12" />
