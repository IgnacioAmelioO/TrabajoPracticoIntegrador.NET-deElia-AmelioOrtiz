using Api.Clients;
using System.Net.Http;
using System.Text.Json;

namespace WindowsForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    loginButton.Enabled = false;
                    loginButton.Text = "Iniciando sesión...";

                    var authService = AuthServiceProvider.Instance;
                    bool success = await authService.LoginAsync(usernameTextBox.Text, passwordTextBox.Text);

                    if (success)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        passwordTextBox.Clear();
                        passwordTextBox.Focus();
                    }
                }
                catch (JsonException ex) 
                {
                    // Specific handling for JSON parsing errors which could cause the Base64 issue
                    MessageBox.Show(
                        $"Error al procesar la respuesta del servidor: {ex.Message}\n\n" +
                        "El servidor respondió con un formato inválido. Contacte al administrador del sistema.",
                        "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (HttpRequestException ex)
                {
                    // Connection errors
                    string baseUrl = GetBaseUrl() ?? "URL no configurada";
                    
                    MessageBox.Show(
                        $"Error al conectar con el servidor API: {ex.Message}\n\n" +
                        $"Verifique que el servidor API esté en ejecución y que la URL sea correcta.\n" +
                        $"URL configurada: {baseUrl}",
                        "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (InvalidOperationException ex)
                {
                    // Handle specific validation errors
                    MessageBox.Show(
                        $"Error en la operación de inicio de sesión: {ex.Message}",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // General errors with more detailed info
                    string errorDetails = $"Error: {ex.Message}";
                    
                    // Add inner exception if available
                    if (ex.InnerException != null)
                    {
                        errorDetails += $"\n\nDetalle: {ex.InnerException.Message}";
                    }
                    
                    // Add instructions for common errors
                    errorDetails += "\n\nPosibles soluciones:" +
                        "\n• Verifique que el servidor API esté en ejecución" +
                        "\n• Verifique su conexión a internet" +
                        "\n• Verifique la URL configurada para la API";

                    MessageBox.Show(errorDetails, "Error al iniciar sesión", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    loginButton.Enabled = true;
                    loginButton.Text = "Iniciar Sesión";
                }
            }
        }

        private string? GetBaseUrl()
        {
            // Reflect the base URL used in the API client
            string? envUrl = Environment.GetEnvironmentVariable("TPI_API_BASE_URL");
            if (!string.IsNullOrEmpty(envUrl))
                return envUrl;
            
            return "https://localhost:7003/"; // This should match the URL in BaseApiClient
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateInput()
        {
            errorProvider.SetError(usernameTextBox, string.Empty);
            errorProvider.SetError(passwordTextBox, string.Empty);

            bool isValid = true;

            if (string.IsNullOrWhiteSpace(usernameTextBox.Text))
            {
                errorProvider.SetError(usernameTextBox, "El nombre de usuario es requerido");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                errorProvider.SetError(passwordTextBox, "La contraseña es requerida");
                isValid = false;
            }

            return isValid;
        }

        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                loginButton_Click(sender, EventArgs.Empty);
                e.Handled = true;
            }
        }
    }
}