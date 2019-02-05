namespace DotCAML
{
    /// <summary>
    /// CAML Field Expression
    /// </summary>
    public interface IFieldExpression
    {
        /// <summary>
        /// Add All operation
        /// </summary>
        /// <param name="conditions">Conditions that all have to be fulfilled</param>
        /// <returns>CAML Expression</returns>
        IExpression All(params IExpression[] conditions);

        /// <summary>
        /// Add Any operation
        /// </summary>
        /// <param name="conditions">Conditions where at least one has to be fulfilled</param>
        /// <returns>CAML Expression</returns>
        IExpression Any(params IExpression[] conditions);

        /// <summary>
        /// Add Text Field reference
        /// </summary>
        /// <param name="internalName">Internal field name</param>
        /// <returns>CAML Text Field Expression</returns>
        ITextFieldExpression TextField(string internalName);

        /// <summary>
        /// Add Choice Field reference
        /// </summary>
        /// <param name="internalName">Internal field name</param>
        /// <returns>CAML Text Field Expression</returns>
        ITextFieldExpression ChoiceField(string internalName);

        /// <summary>
        /// Add Computed Field reference
        /// </summary>
        /// <param name="internalName">Internal field name</param>
        /// <returns>CAML Text Field Expression</returns>
        ITextFieldExpression ComputedField(string internalName);

        /// <summary>
        /// Add Boolean Field reference
        /// </summary>
        /// <param name="internalName">Internal field name</param>
        /// <returns>CAML Boolean Field Expression</returns>
        IBooleanFieldExpression BooleanField(string internalName);

        /// <summary>
        /// Add Url Field reference
        /// </summary>
        /// <param name="internalName">Internal field name</param>
        /// <returns>CAML Text Field Expression</returns>
        ITextFieldExpression UrlField(string internalName);

        /// <summary>
        /// Add Number Field reference
        /// </summary>
        /// <param name="internalName">Internal field name</param>
        /// <returns>CAML Number Field Expression</returns>
        INumberFieldExpression NumberField(string internalName);

        /// <summary>
        /// Add Counter Field reference
        /// </summary>
        /// <param name="internalName">Internal field name</param>
        /// <returns>CAML Number Field Expression</returns>
        INumberFieldExpression CounterField(string internalName);

        /// <summary>
        /// Add Integer Field reference
        /// </summary>
        /// <param name="internalName">Internal field name</param>
        /// <returns>CAML Number Field Expression</returns>
        INumberFieldExpression IntegerField(string internalName);

        /// <summary>
        /// Add User Field reference
        /// </summary>
        /// <param name="internalName">Internal field name</param>
        /// <returns>CAML User Field Expression</returns>
        IUserFieldExpression UserField(string internalName);

        /// <summary>
        /// Add Lookup Field reference
        /// </summary>
        /// <param name="internalName">Internal field name</param>
        /// <returns>CAML Lookup Field Expression</returns>
        ILookupFieldExpression LookupField(string internalName);

        /// <summary>
        /// Add Lookup Multi Field reference
        /// </summary>
        /// <param name="internalName">Internal field name</param>
        /// <returns>CAML Lookup Multi Field Expression</returns>
        ILookupMultiFieldExpression LookupMultiField(string internalName);

        /// <summary>
        /// Add User Multi Field reference
        /// </summary>
        /// <param name="internalName">Internal field name</param>
        /// <returns>CAML User Multi Field Expression</returns>
        IUserMultiFieldExpression UserMultiField(string internalName);

        /// <summary>
        /// Add Date Field reference
        /// </summary>
        /// <param name="internalName">Internal field name</param>
        /// <returns>CAML Date Time Field Expression</returns>
        IDateTimeFieldExpression DateField(string internalName);

        /// <summary>
        /// Add Date Time Field reference
        /// </summary>
        /// <param name="internalName">Internal field name</param>
        /// <returns>CAML Date Time Field Expression</returns>
        IDateTimeFieldExpression DateTimeField(string internalName);

        /// <summary>
        /// Add Mod State Field reference
        /// </summary>
        /// <param name="internalName">Internal field name</param>
        /// <returns>CAML Mod Stat Field Expression</returns>
        IModStatFieldExpression ModStatField(string internalName);

        /// <summary>
        /// Add Date Ranges Overlap condition
        /// </summary>
        /// <param name="overlapType">Overlap type</param>
        /// <param name="calendarDate">Calendar date as yyyy-MM-ddTHH:mm:ssZ string</param>
        /// <param name="eventDateField">Internal field name</param>
        /// <param name="endDateField">Internal field name</param>
        /// <param name="recurrenceIDField">Internal field name</param>
        /// <returns>CAML Expression</returns>
        IExpression DateRangesOverlap(DateRangesOverlapType overlapType, string calendarDate, string eventDateField = null, string endDateField = null, string recurrenceIDField = null);
    }
}