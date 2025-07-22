# Git Workflow Guide - ProjectS Team

## 🌿 Branch Strategy

### **Main Branches**
```
main (protected)
├── develop (integration)
├── feature/player-movement (Hy)
├── feature/environment-design (Kiệt) 
├── feature/ai-system (Hoàng)
└── feature/ui-system (Khánh)
```

### **Branch Naming Convention**
- `feature/[description]` - New features
- `bugfix/[description]` - Bug fixes
- `hotfix/[description]` - Critical fixes
- `release/[version]` - Release preparation

## 📝 Commit Message Format

### **Structure**
```
[TYPE]: Brief description

Detailed explanation (if needed)

Closes #issue-number
```

### **Types**
- `FEAT`: New feature
- `FIX`: Bug fix
- `DOCS`: Documentation
- `STYLE`: Code formatting
- `REFACTOR`: Code refactoring
- `TEST`: Adding tests
- `CHORE`: Maintenance tasks

### **Examples**
```
FEAT: Add player movement controller

- Implement WASD movement
- Add mouse look rotation
- Configure character controller

Closes #15
```

## 🔄 Workflow Steps

### **1. Starting New Work**
```bash
# Switch to develop branch
git checkout develop
git pull origin develop

# Create feature branch
git checkout -b feature/your-feature-name

# Work on your feature...
```

### **2. Daily Work**
```bash
# Add changes
git add .

# Commit with proper message
git commit -m "FEAT: Add basic terrain generation"

# Push to your branch
git push origin feature/your-feature-name
```

### **3. Ready for Review**
```bash
# Update from develop
git checkout develop
git pull origin develop

# Merge develop into your feature
git checkout feature/your-feature-name
git merge develop

# Resolve conflicts if any
# Push updated branch
git push origin feature/your-feature-name

# Create Pull Request on GitHub
```

### **4. Code Review Process**
- Create PR from feature branch to `develop`
- Request review from at least 1 team member
- Address feedback
- Get approval before merging

## 🛡️ Unity-Specific Git Setup

### **.gitignore** (Essential for Unity)
```gitignore
# Unity generated files
/[Ll]ibrary/
/[Tt]emp/
/[Oo]bj/
/[Bb]uild/
/[Bb]uilds/
/[Ll]ogs/
/[Uu]ser[Ss]ettings/

# Unity3D generated meta files
*.pidb.meta
*.pdb.meta
*.mdb.meta

# Unity3D generated file on crash reports
sysinfo.txt

# Builds
*.apk
*.unitypackage

# Crashlytics generated file
crashlytics-build.properties

# Visual Studio cache files
.vs/
```

### **Large File Handling**
```bash
# For large assets (>100MB)
git lfs track "*.fbx"
git lfs track "*.wav"
git lfs track "*.mp3"
git add .gitattributes
git commit -m "CHORE: Setup Git LFS for large assets"
```

## 👥 Team Member Setup

### **First Time Setup (Each Team Member)**
```bash
# Clone repository
git clone https://github.com/HyIsNoob/ProjectS.git

# Configure Git identity
git config user.name "Your Name"
git config user.email "your.email@example.com"

# Create your feature branch
git checkout -b feature/your-area
```

### **GitHub Access**
- **Hy**: Repository owner (admin access)
- **Other members**: Collaborator access needed
- Request access via GitHub invitation

## 🚨 Conflict Resolution

### **Common Unity Conflicts**
1. **Scene files**: Coordinate who works on which scenes
2. **Prefabs**: Create separate prefabs for each system
3. **Project settings**: Only Hy should modify project settings

### **Resolution Steps**
```bash
# When conflict occurs
git status  # See conflicted files

# Edit conflicted files manually
# Or use merge tool
git mergetool

# After resolving
git add resolved-file.cs
git commit -m "FIX: Resolve merge conflict in PlayerController"
```

## 📊 GitHub Project Board

### **Columns Setup**
- 📋 **Backlog**: New tasks
- 🏃 **In Progress**: Currently working
- 👀 **Review**: Waiting for code review
- 🧪 **Testing**: Ready for testing
- ✅ **Done**: Completed tasks

### **Issue Labels**
- `bug` 🐛: Something isn't working
- `enhancement` ✨: New feature request
- `good first issue` 👶: Good for newcomers
- `help wanted` 🙋: Extra attention needed
- `priority-high` 🔴: High priority
- `priority-medium` 🟡: Medium priority
- `priority-low` 🟢: Low priority

## 📅 Release Process

### **Version Numbering**
- Format: `MAJOR.MINOR.PATCH`
- Example: `0.1.0` (Prototype), `0.2.0` (Alpha), `1.0.0` (Release)

### **Release Steps**
1. Create `release/x.x.x` branch from `develop`
2. Test thoroughly
3. Update version numbers
4. Create release notes
5. Merge to `main`
6. Tag release
7. Deploy build

---

**Setup Priority**: High - Complete before starting development
**Next Review**: After first sprint
