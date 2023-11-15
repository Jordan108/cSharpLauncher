using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoverPadLauncher.Clases
{
    public class Themes
    {
        //Atributos
        private Color panelBackground;
        private Color panelTopBackground;

        private Color navbarBackground;
        private Color navbarSelectedBackground;
        private Color navbarText;

        private Color textBoxSearchBackground;
        private Color textBoxSearchText;
        private Color textBoxSearchTextEmpty;
                
        private Color treeViewBackground;
        private Color treeViewHoverBackground;
        private Color treeViewSelectedBackground;
        private Color treeViewBorderBackground;

        //Constructor
        public Themes(string themeDir)
        {
            LoadTheme(themeDir);
            //"System\\Themes\\cyan.css"
        }

        #region Encapsulamiento
        public Color PanelBackground { get { return panelBackground; } }
        public Color PanelTopBackground { get { return panelTopBackground; } }

        public Color TextBoxSearchBackground { get { return textBoxSearchBackground; } }
        public Color TextBoxSearchText { get { return textBoxSearchText; } }
        public Color TextBoxSearchTextEmpty { get { return textBoxSearchTextEmpty; } }

        public Color NavbarBackground { get { return navbarBackground; } }
        public Color NavbarSelectedBackground { get { return navbarSelectedBackground; } }
        public Color NavbarText { get { return navbarText; } }

        public Color TreeViewBackground { get { return treeViewBackground; } }
        public Color TreeViewHoverBackground { get { return treeViewHoverBackground; } }
        public Color TreeViewSelectedBackground { get { return treeViewSelectedBackground; } }

        public Color TreeViewBorderBackground { get {  return treeViewBorderBackground; } }
        #endregion

        //Funciones
        public void LoadTheme(string themeDir)
        {
            //Se carga el tema desde un css


            //Establecer los atributos del color
            //Color loadColor = Color.FromArgb(32, 32, 32);
            this.panelBackground = ObtainColorCSS("--color-bg-panel", themeDir);//loadColor;
            this.panelTopBackground = ObtainColorCSS("--color-bg-top", themeDir);

            this.navbarBackground = ObtainColorCSS("--color-bg-navbar", themeDir);
            this.navbarSelectedBackground = ObtainColorCSS("--color-bg-navbar-selected", themeDir);
            this.navbarText = ObtainColorCSS("--color-text-navbar", themeDir);

            this.textBoxSearchBackground = ObtainColorCSS("--color-bg-searchBox", themeDir);
            this.textBoxSearchText = ObtainColorCSS("--color-text-searchBox", themeDir);
            this.textBoxSearchTextEmpty = ObtainColorCSS("--color-text-empty-searchBox", themeDir);

            this.treeViewBackground = ObtainColorCSS("--color-bg-treeview", themeDir);
            this.treeViewHoverBackground = ObtainColorCSS("--color-bg-treeview-hover", themeDir);
            this.treeViewSelectedBackground = ObtainColorCSS("--color-bg-treeview-selected", themeDir);
            this.treeViewBorderBackground = ObtainColorCSS("--color-bg-treeview-border", themeDir);
        }

        //Metodo para obtener el valor de color de una variable en el archivo CSS
        private static Color ObtainColorCSS(string variable, string rutaArchivo)
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
                            return ObtainColorCSS(variableReferenciada, rutaArchivo);
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
                        return ObtainColorCSS(variableReferenciada, rutaArchivo);
                    }

                    // Si no coincide con ningún formato conocido, devuelve blanco
                    return Color.White;
                }
                Console.WriteLine("\nMatch Fail\n");
                // Si no se encuentra la variable, devuelve blanco
                return Color.White;
            } catch (Exception) {
                return Color.White;
            }
            
        }
    }
}
