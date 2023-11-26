using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CoverPadLauncher.Clases
{
    public class Themes
    {
        //Atributos

        //flowLayoutPanel
        private Color panelBackground;

        //Windows background
        private Color windowBackground;

        //Panel Top
        private Color panelTopBackground;
        private Color panelTopText;

        //navBar
        private Color navbarBackground;
        private Color navbarSelectedBackground;
        private Color navbarText;

        //textBox
        private Color textBoxBackground;
        private Color textBoxText;

        //searchBox
        private Color textBoxSearchBackground;
        private Color textBoxSearchText;
        private Color textBoxSearchTextEmpty;

        //Combobox
        private Color comboboxBackground;
        private Color comboboxText;

        //Botones
        private Color buttonBackground;
        private Color buttonText;

        //Control numerico
        private Color numericBackground;
        private Color numericText;

        //Fondo de la vista previa de la caratula
        private Color coverPreviewBackground;

        //default label
        private Color labelText;

        //cover selected border
        private Color coverSelected;

        //TreeView
        private Color treeViewBackground;
        private Color treeViewHoverBackground;
        private Color treeViewSelectedBackground;
        private Color treeViewBorderBackground;
        private Color treeViewText;

        //DataGridView
        private Color dataGridBackground;
        private Color dataGridCellBackground;
        private Color dataGridCellText;
        private Color dataGridSelectedBackground;
        private Color dataGridSelectedText;
        private Color dataGridBorder;

        //Constructor
        public Themes(string themeDir)
        {
            LoadTheme(themeDir);
        }

        #region Encapsulamiento

        //flowLayoutPanel
        public Color PanelBackground { get { return panelBackground; } }

        //Fondo de ventanas
        public Color WindowBackground { get { return windowBackground; } }

        //Panel Top
        public Color PanelTopBackground { get { return panelTopBackground; } }
        public Color PanelTopText { get { return panelTopText; } }

        //searchBox
        public Color TextBoxSearchBackground { get { return textBoxSearchBackground; } }
        public Color TextBoxSearchText { get { return textBoxSearchText; } }
        public Color TextBoxSearchTextEmpty { get { return textBoxSearchTextEmpty; } }

        //textBox
        public Color TextBoxBackground { get { return textBoxBackground; } }
        public Color TextBoxText { get { return textBoxText; } }

        //Combobox
        public Color ComboboxBackground { get { return comboboxBackground; } }
        public Color ComboboxText { get { return comboboxText; } }

        //Botones
        public Color ButtonBackground { get { return buttonBackground; } }
        public Color ButtonText { get { return buttonText; } }

        //navBar
        public Color NavbarBackground { get { return navbarBackground; } }
        public Color NavbarSelectedBackground { get { return navbarSelectedBackground; } }
        public Color NavbarText { get { return navbarText; } }

        //Control numerico
        public Color NumericBackground { get { return numericBackground; } }
        public Color NumericText { get { return numericText; } }

        //Fondo de la vista previa de la caratula
        public Color CoverPreviewBackground { get { return coverPreviewBackground; } }

        //default label
        public Color LabelText { get { return labelText; } }

        //cover selected border
        public Color CoverSelected { get { return coverSelected; } }

        //TreeView
        public Color TreeViewBackground { get { return treeViewBackground; } }
        public Color TreeViewHoverBackground { get { return treeViewHoverBackground; } }
        public Color TreeViewSelectedBackground { get { return treeViewSelectedBackground; } }
        public Color TreeViewBorderBackground { get {  return treeViewBorderBackground; } }
        public Color TreeViewText { get { return treeViewText; } }

        //DataGridView
        public Color DataGridBackground { get { return dataGridBackground; } }
        public Color DataGridCellBackground { get { return dataGridCellBackground; } }
        public Color DataGridCellText { get { return dataGridCellText; } }
        public Color DataGridSelectedBackground { get { return dataGridSelectedBackground; } }
        public Color DataGridSelectedText { get { return dataGridSelectedText;  } }
        public Color DataGridBorder { get { return dataGridBorder; } }
        #endregion

        //Funciones
        public void LoadTheme(string themeDir)
        {
            //Colores por defecto
            Color mainColor = Color.FromArgb(36, 40, 47);
            Color lightColor = Color.FromArgb(94, 105, 123);
            Color darkColor = Color.FromArgb(23, 29, 37);
            Color defaultText = Color.White;

            //Establecer los atributos del color; Se carga el tema desde un css
            //flowLayoutPanel
            this.panelBackground = ObtainColorCSS("--color-bg-panel", themeDir, mainColor);//loadColor;

            //Fondo de las ventanas
            this.windowBackground = ObtainColorCSS("--color-bg-window", themeDir, Color.FromArgb(55, 61, 72));

            //Panel Top
            this.panelTopBackground = ObtainColorCSS("--color-bg-top", themeDir, darkColor);
            this.panelTopText = ObtainColorCSS("--color-text-top", themeDir, defaultText);

            //navBar
            this.navbarBackground = ObtainColorCSS("--color-bg-navbar", themeDir, darkColor);
            this.navbarSelectedBackground = ObtainColorCSS("--color-bg-navbar-selected", themeDir, lightColor);
            this.navbarText = ObtainColorCSS("--color-text-navbar", themeDir, defaultText);

            //textBox
            this.textBoxBackground = ObtainColorCSS("--color-bg-textBox", themeDir, mainColor);
            this.textBoxText = ObtainColorCSS("--color-text-textBox", themeDir, defaultText);

            //Combobox
            this.comboboxBackground = ObtainColorCSS("--color-bg-comboBox", themeDir, lightColor);
            this.comboboxText = ObtainColorCSS("--color-text-comboBox", themeDir, defaultText);

            //Botones
            this.buttonBackground = ObtainColorCSS("--color-bg-button", themeDir, lightColor);
            this.buttonText = ObtainColorCSS("--color-text-button", themeDir, defaultText);

            //Control numerico
            this.numericBackground = ObtainColorCSS("--color-bg-numericUpDown", themeDir, mainColor);
            this.numericText = ObtainColorCSS("--color-text-numericUpDown", themeDir, defaultText);

            //Fondo de la vista previa de la caratula
            this.coverPreviewBackground = ObtainColorCSS("--color-bg-coverPanelPreview", themeDir, mainColor);

            //default label
            this.labelText = ObtainColorCSS("--color-text-label", themeDir, defaultText);

            //cover selected border
            this.coverSelected = ObtainColorCSS("--color-border-cover", themeDir, Color.White);

            //searchBox
            this.textBoxSearchBackground = ObtainColorCSS("--color-bg-searchBox", themeDir, mainColor);
            this.textBoxSearchText = ObtainColorCSS("--color-text-searchBox", themeDir, defaultText);
            this.textBoxSearchTextEmpty = ObtainColorCSS("--color-text-empty-searchBox", themeDir, Color.FromArgb(128, 128, 128));

            //TreeView
            this.treeViewBackground = ObtainColorCSS("--color-bg-treeview", themeDir, lightColor);
            this.treeViewHoverBackground = ObtainColorCSS("--color-bg-treeview-hover", themeDir,Color.FromArgb(73, 81, 95));
            this.treeViewSelectedBackground = ObtainColorCSS("--color-bg-treeview-selected", themeDir, Color.FromArgb(65, 72, 85));
            this.treeViewBorderBackground = ObtainColorCSS("--color-bg-treeview-border", themeDir, darkColor);
            this.treeViewText = ObtainColorCSS("--color-text-treeview", themeDir, defaultText);

            //DataGridView
            this.dataGridBackground = ObtainColorCSS("--color-bg-grid", themeDir, darkColor);
            this.dataGridCellBackground = ObtainColorCSS("--color-bg-grid-cell", themeDir, darkColor);
            this.dataGridCellText = ObtainColorCSS("--color-text-grid-cell", themeDir, defaultText);
            this.dataGridSelectedBackground = ObtainColorCSS("--color-bg-grid-cell-selected", themeDir, lightColor);
            this.dataGridSelectedText = ObtainColorCSS("--color-text-grid-cell-selected", themeDir, defaultText);
            this.dataGridBorder = ObtainColorCSS("--color-bg-grid-border", themeDir, darkColor);
        }

        //Metodo para obtener el valor de color de una variable en el archivo CSS
        private static Color ObtainColorCSS(string variable, string rutaArchivo, Color defaultColor)
        {
            //Debido a que el usuario puede manipular a su gusto el archivo css, si encuentra un error devolvera un color blanco
            try
            {
                // Eliminar comentarios de CSS antes de analizar
                var cssContent = System.IO.File.ReadAllText(rutaArchivo);
                cssContent = Regex.Replace(cssContent, @"/\*.*?\*/", "", RegexOptions.Singleline);

                var regex = new Regex($"{variable}:\\s*([^;]+);", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                var match = regex.Match(cssContent);


                if (match.Success)
                {
                    var valorVariable = match.Groups[1].Value.Trim();

                    Console.WriteLine($"\nMatch succes, value {valorVariable}\n");

                    //Dependiendo de si el color es rgb o hexadecimal el proceso es diferente
                    if (valorVariable.StartsWith("rgb("))
                    {
                        if (valorVariable.Substring(4, 8).StartsWith("var("))
                        {
                            // Si el valor es otra variable, busca su valor recursivamente (8 es el despues de rgb(var(; -2 son los ultimos 2 parentesis ))
                            var variableReferenciada = valorVariable.Substring(8, valorVariable.Length - 10).Trim();//el -10 es la suma de la longitud de rgb(var()) (son 10 caracteres)
                            return ObtainColorCSS(variableReferenciada, rutaArchivo, defaultColor);
                        }
                        else
                        {
                            // Si el valor es una función rgb(), parsea los valores de color
                            var valoresRgb = valorVariable.Substring(4, valorVariable.Length - 5)
                                .Split(',')
                                .Select(int.Parse)
                                .ToArray();
                            return Color.FromArgb(valoresRgb[0], valoresRgb[1], valoresRgb[2]);
                        }

                    }
                    else if (valorVariable.StartsWith("#"))
                    {
                        // Si el valor es un código hexadecimal
                        return ColorTranslator.FromHtml(valorVariable);
                    }
                    else if (valorVariable.StartsWith("var("))
                    {
                        // Si el valor es otra variable, busca su valor recursivamente 
                        var variableReferenciada = valorVariable.Substring(4, valorVariable.Length - 5).Trim();
                        return ObtainColorCSS(variableReferenciada, rutaArchivo, defaultColor);
                    }

                    // Si no coincide con ningún formato conocido, devuelve blanco
                    return defaultColor;
                }
                Console.WriteLine("\nMatch Fail\n");
                // Si no se encuentra la variable, devuelve blanco
                return defaultColor;
            } catch (Exception) {
                return defaultColor;
            }
            
        }
    }
}
